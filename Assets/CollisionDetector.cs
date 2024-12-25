using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

// [REF]
//  Hatena: Unity�̏Փ˔���𐔒l�����ĕs����ȐڐG�����艻���� https://nnana-gamedev.hatenablog.com/entry/2017/12/02/203824


namespace nitou.Develop {

    public class CollisionDetector : MonoBehaviour {

        [Header("Parameters")]
        [SerializeField] private float _cutOffFrequency = 30.0f;

        // �Փˑ���̃^�O���`�F�b�N���邩���Ȃ���
        public bool checkOtherTag = true;
        public string targetTag;

        // �t�B���^�p�̒萔�F�傫���قǏՓ˔��肪�ω����ɂ����Ȃ����
        private float _filterConstant;

        // Time.fixedDeltaTime�̕ω����Ď�
        private float _fixedDeltaTimeObserved;
        
        // �Փ˔����臒l�F����Ɖ�����p�ӂ��Ĕ���̕ω��Ƀq�X�e���V�X����������
        [Range(0.0f, 1.0f)] public float detectionThresholdUpper = 0.9f;
        [Range(0.0f, 1.0f)] public float detectionThresholdLower = 0.1f;

        // �Փˏ��ێ�
        private Collision _otherOnEnter;
        private Collision _otherOnStay;
        private Collision _otherOnExit;

        private bool _onCollision = false;
        
        [SerializeField] private bool _onCollisionEnter = false;
        [SerializeField] private bool _onCollisionStay = false;
        [SerializeField] private bool _onCollisionExit = false;
        
        // �Փ˔���̕����p
        private bool _onCollisionRaw = false;
        private float _onCollisionFloat = 0.0f;

        // ����
        private Subject<Collision> _onCollisionEnterSubject = new();
        private Subject<Collision> _onCollisionStaySbuject = new();
        private Subject<Collision> _onCollisionExitSubject = new();

        
        /// ----------------------------------------------------------------------------
        
        // �J�b�g�I�t���g���F�������قǋ}�ȓ������}�������
        public float CutOffFrequency {
            get => _cutOffFrequency;
            set {
                _cutOffFrequency = value;
                CalculateFilterConstant();
            }
        }

        // �Փ˃t���O
        public bool OnCollisionEnter => _onCollisionEnter;
        public bool OnCollisionStay => _onCollisionStay;
        public bool OnCollisionExit => _onCollisionExit;

        // �w�ǗpObservable
        public IObservable<Collision> OnCollisionEnterSmoothedAsObservable => _onCollisionEnterSubject;
        public IObservable<Collision> OnCollisionStaySmoothedAsObservable => _onCollisionStaySbuject;
        public IObservable<Collision> OnCollisionExitSmoothedAsObservable => _onCollisionExitSubject;


		/// ----------------------------------------------------------------------------

		void Start() {
			// �l�̏�����
			if (_onCollision)
				_onCollisionFloat = 1.0f;
			else
				_onCollisionFloat = 0.0f;

			_fixedDeltaTimeObserved = Time.fixedDeltaTime;
			CalculateFilterConstant();

			// OnCollisionEnter
			this.OnCollisionEnterAsObservable()
				.Subscribe(other => {
					// �^�O����v���Ȃ��ꍇ�͉������Ȃ�
					if (checkOtherTag == false || other.gameObject.CompareTag(targetTag) == true) {
						_onCollisionRaw = true;
						_otherOnEnter = other;
						_otherOnStay = other;
					}
				});
			// OnCollisionStay
			this.OnCollisionStayAsObservable()
				.Subscribe(other => {
					// �^�O����v���Ȃ��ꍇ�͉������Ȃ�
					if (checkOtherTag == false || other.gameObject.CompareTag(targetTag) == true) {
						_otherOnStay = other;
					}
				});
			// OnCollisionExit
			this.OnCollisionExitAsObservable()
				.Subscribe(other => {
					// �^�O����v���Ȃ��ꍇ�͉������Ȃ�
					if (checkOtherTag == false || other.gameObject.CompareTag(targetTag) == true) {
						_onCollisionRaw = false;
						_otherOnExit = other;
					}
				});
			// FixedUpdate���ŕ����������Փ˔�����v�Z
			this.FixedUpdateAsObservable()
				.Subscribe(_ => {
					// Time.fixedDeltaTime���ύX���ꂽ�ꍇ�̓t�B���^�̒萔���X�V
					if (Mathf.Approximately(Time.fixedDeltaTime, _fixedDeltaTimeObserved) == false) {
						_fixedDeltaTimeObserved = Time.fixedDeltaTime;
						CalculateFilterConstant();
					}

					// 1�T�C�N���O�̏Փˏ���ێ�����Enter, Stay, Exit�̔���Ɏg�p
					bool onCollisionPrevious = _onCollision;
					int onCollisionCurrent = 0;
					if (_onCollisionRaw)
						onCollisionCurrent = 1;
					// �Փ˂��Ă��邩�ǂ����𐔒l���B_filterConstant���傫���ق�1�T�C�N���O�̏�Ԃ�D��
					_onCollisionFloat = (1.0f - _filterConstant) * onCollisionCurrent + _filterConstant * _onCollisionFloat;

					// _onCollisionFloat�̒l��0.0~1.0�ɐ���
					if (_onCollisionFloat > 1.0f)
						_onCollisionFloat = 1.0f;
					else if (_onCollisionFloat < 0.0f)
						_onCollisionFloat = 0.0f;

					if (onCollisionPrevious) {
						// 1�O�̃T�C�N���ŏՓ˂��Ă���ꍇ�A����臒l�������܂ŏ�Ԃ�ω������Ȃ�
						if (_onCollisionFloat <= detectionThresholdLower)
							_onCollision = false;
						else
							_onCollision = true;
					} else {
						// 1�O�̃T�C�N���ŏՓ˂��Ă��Ȃ��ꍇ�A���臒l������܂ŏ�Ԃ�ω������Ȃ�
						if (_onCollisionFloat >= detectionThresholdUpper)
							_onCollision = true;
						else
							_onCollision = false;
					}

					// OnCollisionEnter���AStay���AExit������
					if (_onCollision == onCollisionPrevious) {
						_onCollisionEnter = false;
						_onCollisionExit = false;
					} else {
						if (_onCollision) {
							// OnNext�ŃC�x���g�ʒm
							_onCollisionEnter = true;
							_onCollisionEnterSubject.OnNext(_otherOnEnter);
						} else {
							// OnNext�ŃC�x���g�ʒm
							_onCollisionExit = true;
							_onCollisionExitSubject.OnNext(_otherOnExit);
						}
					}
					_onCollisionStay = _onCollision;
					// OnNext�ŃC�x���g�ʒm
					if (_onCollisionStay)
						_onCollisionStaySbuject.OnNext(_otherOnStay);
				});
		}


		/// ----------------------------------------------------------------------------
		// Public Method

		/// �J�b�g�I�t���g������Փ˔��蕽���p�̒萔���v�Z
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