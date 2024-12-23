using UnityEngine;
using MackySoft.Navigathena.SceneManagement;
using Cysharp.Threading.Tasks;
using UniRx;

using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;
using Project.Infrastructure.Setting;
using Project.UseCase.Setting;

namespace App.Composition {

    public sealed class ApplicationRoot : MonoBehaviour {


        //private readonly ISceneIdentifier homeScene = new BuiltInSceneIdentifier("Home");
        //private readonly ISceneIdentifier stageScene = new BuiltInSceneIdentifier("Stage");

        private async void Start() {

            await UniTask.Yield();


            // Repository
            var soundRepository = new PlayerPrefsSoundSettingsRepository() as ISoundSettingsRepository;

            var soundSettingsSet = await soundRepository.LoadAsync();

            // Model
            var settingsModel = new SettingsModel(soundSettingsSet);

            // UseCase
            var settingsUseCase = new SoundSettingsUseCase(settingsModel, soundRepository);



            // 設定変更を監視
            settingsModel.SoundSettingsSetRP.Subscribe(settings => {
                Debug.Log($"Voice: {settings.Voice.Volume}, Muted: {settings.Voice.Muted}");
                Debug.Log($"BGM: {settings.Bgm.Volume}, Muted: {settings.Bgm.Muted}");
                Debug.Log($"SE: {settings.Se.Volume}, Muted: {settings.Se.Muted}");
            });

            // 設定をロード
            await settingsUseCase.LoadSoundSettingsAsync();

            // 設定を変更
            var updatedSettings = settingsModel.SoundSettingsSetRP.Value.WithVoice(
                settingsModel.SoundSettingsSetRP.Value.Voice.WithVolume(0.8f)
            );
            settingsUseCase.UpdateSoundSettings(updatedSettings);

            // 設定を保存
            await settingsUseCase.SaveSoundSettingsAsync();

        }


    }

}