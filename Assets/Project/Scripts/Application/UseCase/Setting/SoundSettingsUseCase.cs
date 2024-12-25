using System;
using Cysharp.Threading.Tasks;
using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;

namespace Project.UseCase.Setting {

    /// <summary>
    /// ���ʐݒ�Ɋւ��郆�[�X�P�[�X�D
    /// </summary>
    public sealed class SoundSettingsUseCase {

        private readonly SettingsModel _model;
        private readonly ISoundSettingsRepository _repository;


        public SettingsModel Model => _model;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public SoundSettingsUseCase(SettingsModel model, ISoundSettingsRepository repository) {
            _model = model;
            _repository = repository;
        }
        
        /// <summary>
        /// ���f���ɐݒ�l��ǂݍ��ށD
        /// </summary>
        public async UniTask LoadSoundSettingsAsync() {
            var loadedSettings = await _repository.LoadAsync();
            _model.UpdateSoundSettings(loadedSettings);
        }
        
        /// <summary>
        /// ���f���̐ݒ�l��ۑ�����D
        /// </summary>
        public async UniTask SaveSoundSettingsAsync() {
            var currentSettings = _model.SoundsRP.Value;
            await _repository.SaveAsync(currentSettings);
        }

        /// <summary>
        /// ���f���̐ݒ�l���X�V����D
        /// </summary>
        public void UpdateSoundSettings(SoundSettingsSet newSettings) {
            _model.UpdateSoundSettings(newSettings);
        }
    }
}
