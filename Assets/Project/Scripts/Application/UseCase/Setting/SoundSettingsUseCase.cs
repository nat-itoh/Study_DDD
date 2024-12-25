using System;
using Cysharp.Threading.Tasks;
using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;

namespace Project.UseCase.Setting {

    /// <summary>
    /// 音量設定に関するユースケース．
    /// </summary>
    public sealed class SoundSettingsUseCase {

        private readonly SettingsModel _model;
        private readonly ISoundSettingsRepository _repository;


        public SettingsModel Model => _model;


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public SoundSettingsUseCase(SettingsModel model, ISoundSettingsRepository repository) {
            _model = model;
            _repository = repository;
        }
        
        /// <summary>
        /// モデルに設定値を読み込む．
        /// </summary>
        public async UniTask LoadSoundSettingsAsync() {
            var loadedSettings = await _repository.LoadAsync();
            _model.UpdateSoundSettings(loadedSettings);
        }
        
        /// <summary>
        /// モデルの設定値を保存する．
        /// </summary>
        public async UniTask SaveSoundSettingsAsync() {
            var currentSettings = _model.SoundsRP.Value;
            await _repository.SaveAsync(currentSettings);
        }

        /// <summary>
        /// モデルの設定値を更新する．
        /// </summary>
        public void UpdateSoundSettings(SoundSettingsSet newSettings) {
            _model.UpdateSoundSettings(newSettings);
        }
    }
}
