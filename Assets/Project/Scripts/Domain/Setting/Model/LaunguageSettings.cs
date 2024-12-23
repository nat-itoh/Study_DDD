using System;
using UniRx;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// 言語設定．言語や地域に関連する設定を管理する．
    /// </summary>
    public class LaunguageSettings : IDisposable{

        private readonly Subject<ValueChangedEvent> _valueChangedSubject = new();

        /// <summary>
        /// 言語コード．
        /// （e.g., "en-US", "ja-JP"）
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// 地域コード．
        /// （e.g., "US", "JP"）
        /// </summary>
        public string RegionCode { get; private set; }

        /// <summary>
        /// 値が変化したときに通知するObservable．
        /// </summary>
        public IObservable<ValueChangedEvent> ValueChanged => _valueChangedSubject;


        /// <summary>
        /// 値を設定する．
        /// </summary>
        internal void SetValues(string languageCode, string regionCode) {
            LanguageCode = languageCode;
            RegionCode = regionCode;
            _valueChangedSubject.OnNext(new ValueChangedEvent(languageCode, regionCode));
        }

        /// <summary>
        /// 終了処理．
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
