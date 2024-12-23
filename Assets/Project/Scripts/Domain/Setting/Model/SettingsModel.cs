using System;
using UniRx;

namespace Project.Domain.Setting.Model {

    public sealed class SettingsModel : IDisposable {

        private readonly ReactiveProperty<SoundSettingsSet> _soundSettingsSetRP;

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyReactiveProperty<SoundSettingsSet> SoundSettingsSetRP => _soundSettingsSetRP;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public SettingsModel(SoundSettingsSet initialSettings) {
            _soundSettingsSetRP = new ReactiveProperty<SoundSettingsSet>(initialSettings);
        }
                
        /// <summary>
        /// 終了処理．
        /// </summary>
        public void Dispose() {

        }


        /// ----------------------------------------------------------------------------
        // Internal Method

        /// <summary>
        /// サウンド設定を更新．
        /// </summary>
        internal void UpdateSoundSettings(SoundSettingsSet newSettings) {
            _soundSettingsSetRP.Value = newSettings;
        }
    }
}
