using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

// [REF]
//  Hatena: Unityの衝突判定を数値化して不安定な接触を安定化する https://nnana-gamedev.hatenablog.com/entry/2017/12/02/203824


namespace nitou.Develop {

    public class CollisionDetector : MonoBehaviour {

        [Header("Parameters")]
        [SerializeField] private float _cutOffFrequency = 30.0f;

        // 衝突相手のタグをチェックするかしないか
        public bool checkOtherTag = true;
        public string targetTag;

        // フィルタ用の定数：大きいほど衝突判定が変化しにくくなり安定
        private float _filterConstant;

        // Time.fixedDeltaTimeの変化を監視
        private float _fixedDeltaTimeObserved;
        
        // 衝突判定の閾値：上限と下限を用意して判定の変化にヒステリシスを持たせる
        [Range(0.0f, 1.0f)] public float detectionThresholdUpper = 0.9f;
        [Range(0.0f, 1.0f)] public float detectionThresholdLower = 0.1f;

        // 衝突情報保持
        private Collision _otherOnEnter;
        private Collision _otherOnStay;
        private Collision _otherOnExit;

        private bool _onCollision = false;
        
        [SerializeField] private bool _onCollisionEnter = false;
        [SerializeField] private bool _onCollisionStay = false;
        [SerializeField] private bool _onCollisionExit = false;
        
        // 衝突判定の平滑用
        private bool _onCollisionRaw = false;
        private float _onCollisionFloat = 0.0f;

        // 実装
        private Subject<Collision> _onCollisionEnterSubject = new();
        private Subject<Collision> _onCollisionStaySbuject = new();
        private Subject<Collision> _onCollisionExitSubject = new();

        
        /// ----------------------------------------------------------------------------
        
        // カットオフ周波数：小さいほど急な動きが抑制される
        public float CutOffFrequency {
            get => _cutOffFrequency;
            set {
                _cutOffFrequency = value;
                CalculateFilterConstant();
            }
        }

        // 衝突フラグ
        public bool OnCollisionEnter => _onCollisionEnter;
        public bool OnCollisionStay => _onCollisionStay;
        public bool OnCollisionExit => _onCollisionExit;

        // 購読用Observable
        public IObservable<Collision> OnCollisionEnterSmoothedAsObservable => _onCollisionEnterSubject;
        public IObservable<Collision> OnCollisionStaySmoothedAsObservable => _onCollisionStaySbuject;
        public IObservable<Collision> OnCollisionExitSmoothedAsObservable => _onCollisionExitSubject;


		/// ----------------------------------------------------------------------------

		void Start() {
			// 値の初期化
			if (_onCollision)
				_onCollisionFloat = 1.0f;
			else
				_onCollisionFloat = 0.0f;

			_fixedDeltaTimeObserved = Time.fixedDeltaTime;
			CalculateFilterConstant();

			// OnCollisionEnter
			this.OnCollisionEnterAsObservable()
				.Subscribe(other => {
					// タグが一致しない場合は何もしない
					if (checkOtherTag == false || other.gameObject.CompareTag(targetTag) == true) {
						_onCollisionRaw = true;
						_otherOnEnter = other;
						_otherOnStay = other;
					}
				});
			// OnCollisionStay
			this.OnCollisionStayAsObservable()
				.Subscribe(other => {
					// タグが一致しない場合は何もしない
					if (checkOtherTag == false || other.gameObject.CompareTag(targetTag) == true) {
						_otherOnStay = other;
					}
				});
			// OnCollisionExit
			this.OnCollisionExitAsObservable()
				.Subscribe(other => {
					// タグが一致しない場合は何もしない
					if (checkOtherTag == false || other.gameObject.CompareTag(targetTag) == true) {
						_onCollisionRaw = false;
						_otherOnExit = other;
					}
				});
			// FixedUpdate内で平滑化した衝突判定を計算
			this.FixedUpdateAsObservable()
				.Subscribe(_ => {
					// Time.fixedDeltaTimeが変更された場合はフィルタの定数を更新
					if (Mathf.Approximately(Time.fixedDeltaTime, _fixedDeltaTimeObserved) == false) {
						_fixedDeltaTimeObserved = Time.fixedDeltaTime;
						CalculateFilterConstant();
					}

					// 1サイクル前の衝突情報を保持してEnter, Stay, Exitの判定に使用
					bool onCollisionPrevious = _onCollision;
					int onCollisionCurrent = 0;
					if (_onCollisionRaw)
						onCollisionCurrent = 1;
					// 衝突しているかどうかを数値化。_filterConstantが大きいほど1サイクル前の状態を優先
					_onCollisionFloat = (1.0f - _filterConstant) * onCollisionCurrent + _filterConstant * _onCollisionFloat;

					// _onCollisionFloatの値を0.0~1.0に制限
					if (_onCollisionFloat > 1.0f)
						_onCollisionFloat = 1.0f;
					else if (_onCollisionFloat < 0.0f)
						_onCollisionFloat = 0.0f;

					if (onCollisionPrevious) {
						// 1つ前のサイクルで衝突している場合、下限閾値を下回るまで状態を変化させない
						if (_onCollisionFloat <= detectionThresholdLower)
							_onCollision = false;
						else
							_onCollision = true;
					} else {
						// 1つ前のサイクルで衝突していない場合、上限閾値を上回るまで状態を変化させない
						if (_onCollisionFloat >= detectionThresholdUpper)
							_onCollision = true;
						else
							_onCollision = false;
					}

					// OnCollisionEnterか、Stayか、Exitか判定
					if (_onCollision == onCollisionPrevious) {
						_onCollisionEnter = false;
						_onCollisionExit = false;
					} else {
						if (_onCollision) {
							// OnNextでイベント通知
							_onCollisionEnter = true;
							_onCollisionEnterSubject.OnNext(_otherOnEnter);
						} else {
							// OnNextでイベント通知
							_onCollisionExit = true;
							_onCollisionExitSubject.OnNext(_otherOnExit);
						}
					}
					_onCollisionStay = _onCollision;
					// OnNextでイベント通知
					if (_onCollisionStay)
						_onCollisionStaySbuject.OnNext(_otherOnStay);
				});
		}


		/// ----------------------------------------------------------------------------
		// Public Method

		/// カットオフ周波数から衝突判定平滑用の定数を計算
		public void CalculateFilterConstant() {
            _filterConstant = Mathf.Exp(-CutOffFrequency * _fixedDeltaTimeObserved);
        }


        /// ----------------------------------------------------------------------------
#if UNITY_EDITOR
        private void OnValidate() {
            CalculateFilterConstant();
        }
#endif
    }

}