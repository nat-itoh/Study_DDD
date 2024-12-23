using System;
using UniRx;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// 画質設定．ゲームの描画品質に関連する設定を管理する．
    /// </summary>
    public sealed class GraphicsSettings {

        private readonly Subject<ValueChangedEvent> _valueChangedSubject = new();

        /// <summary>
        /// 画面
        /// </summary>
        public int ResolutionWidth { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int ResolutionHeight { get; private set; }

        /// <summary>
        /// フル画面表示かどうか．
        /// </summary>
        public bool FullScreen { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int GraphicsQuality { get; private set; } // 0: Low, 1: Medium, 2: High, etc.

        /// <summary>
        /// 値が変化したときに通知するObservable．
        /// </summary>
        public IObservable<ValueChangedEvent> ValueChanged => _valueChangedSubject;

        /// <summary>
        /// 値を設定する．
        /// </summary>
        internal void SetValues(int width, int height, bool fullScreen, int quality) {
            ResolutionWidth = width;
            ResolutionHeight = height;
            FullScreen = fullScreen;
            GraphicsQuality = quality;
            _valueChangedSubject.OnNext(new ValueChangedEvent(width, height, fullScreen, quality));
        }

        /// <summary>
        /// 終了処理．
        /// </summary>
        public void Dispose() {
            _valueChangedSubject.Dispose();
        }


        public readonly struct ValueChangedEvent {
            public ValueChangedEvent(int width, int height, bool fullScreen, int quality) {
                ResolutionWidth = width;
                ResolutionHeight = height;
                FullScreen = fullScreen;
                GraphicsQuality = quality;
            }

            public int ResolutionWidth { get; }
            public int ResolutionHeight { get; }
            public bool FullScreen { get; }
            public int GraphicsQuality { get; }
        }
    }
}
