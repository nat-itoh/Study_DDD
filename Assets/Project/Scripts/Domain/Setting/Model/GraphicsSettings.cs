using System;
using UniRx;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// �掿�ݒ�D�Q�[���̕`��i���Ɋ֘A����ݒ���Ǘ�����D
    /// </summary>
    public sealed class GraphicsSettings {

        private readonly Subject<ValueChangedEvent> _valueChangedSubject = new();

        /// <summary>
        /// ���
        /// </summary>
        public int ResolutionWidth { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int ResolutionHeight { get; private set; }

        /// <summary>
        /// �t����ʕ\�����ǂ����D
        /// </summary>
        public bool FullScreen { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int GraphicsQuality { get; private set; } // 0: Low, 1: Medium, 2: High, etc.

        /// <summary>
        /// �l���ω������Ƃ��ɒʒm����Observable�D
        /// </summary>
        public IObservable<ValueChangedEvent> ValueChanged => _valueChangedSubject;

        /// <summary>
        /// �l��ݒ肷��D
        /// </summary>
        internal void SetValues(int width, int height, bool fullScreen, int quality) {
            ResolutionWidth = width;
            ResolutionHeight = height;
            FullScreen = fullScreen;
            GraphicsQuality = quality;
            _valueChangedSubject.OnNext(new ValueChangedEvent(width, height, fullScreen, quality));
        }

        /// <summary>
        /// �I�������D
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
