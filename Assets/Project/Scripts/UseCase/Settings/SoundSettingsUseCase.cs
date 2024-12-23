using System;
using Cysharp.Threading.Tasks;
using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;

namespace Project.UseCase.Setting {

    public sealed class SoundSettingsUseCase {

        private readonly SettingsModel _model;
        private readonly ISoundSettingsRepository _repository;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public SoundSettingsUseCase(SettingsModel model, ISoundSettingsRepository repository) {
            _model = model;
            _repository = repository;
        }
                
        public async UniTask LoadSoundSettingsAsync() {
            var loadedSettings = await _repository.LoadAsync();
            _model.UpdateSoundSettings(loadedSettings);
        }
        
        public async UniTask SaveSoundSettingsAsync() {
            var currentSettings = _model.SoundSettingsSetRP.Value;
            await _repository.SaveAsync(currentSettings);
        }

        public void UpdateSoundSettings(SoundSettingsSet newSettings) {
            _model.UpdateSoundSettings(newSettings);
        }
    }
}
