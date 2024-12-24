using System;
using UniRx;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// ����ݒ�D�����n��Ɋ֘A����ݒ���Ǘ�����D
    /// </summary>
    public class LaunguageSettings : IDisposable{

        private readonly Subject<ValueChangedEvent> _valueChangedSubject = new();

        /// <summary>
        /// ����R�[�h�D
        /// �ie.g., "en-US", "ja-JP"�j
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// �n��R�[�h�D
        /// �ie.g., "US", "JP"�j
        /// </summary>
        public string RegionCode { get; private set; }

        /// <summary>
        /// �l���ω������Ƃ��ɒʒm����Observable�D
        /// </summary>
        public IObservable<ValueChangedEvent> ValueChanged => _valueChangedSubject;


        /// <summary>
        /// �l��ݒ肷��D
        /// </summary>
        internal void SetValues(string languageCode, string regionCode) {
            LanguageCode = languageCode;
            RegionCode = regionCode;
            _valueChangedSubject.OnNext(new ValueChangedEvent(languageCode, regionCode));
        }

        /// <summary>
        /// �I�������D
        /// </summary>
        public void Dispose() {
            _valueChangedSubject.Dispose();
        }


        public readonly struct ValueChangedEvent {
            public ValueChangedEvent(string languageCode, string regionCode) {
                LanguageCode = languageCode;
                RegionCode = regionCode;
            }

            public string LanguageCode { get; }
            public string RegionCode { get; }
        }
    }
}
