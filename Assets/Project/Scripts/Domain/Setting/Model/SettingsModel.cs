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
        /// �R���X�g���N�^�D
        /// </summary>
        public SettingsModel(SoundSettingsSet initialSettings) {
            _soundSettingsSetRP = new ReactiveProperty<SoundSettingsSet>(initialSettings);
        }
                
        /// <summary>
        /// �I�������D
        /// </summary>
        public void Dispose() {

        }


        /// ----------------------------------------------------------------------------
        // Internal Method

        /// <summary>
        /// �T�E���h�ݒ���X�V�D
        /// </summary>
        internal void UpdateSoundSettings(SoundSettingsSet newSettings) {
            _soundSettingsSetRP.Value = newSettings;
        }
    }
}
