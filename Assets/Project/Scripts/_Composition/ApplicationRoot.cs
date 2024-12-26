using UnityEngine;
using MackySoft.Navigathena.SceneManagement;
using Cysharp.Threading.Tasks;
using UniRx;

using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;
using Project.Infrastructure.Setting;
using Project.UseCase.Setting;
using Project.View.Setting;
using Project.Presentation.Setting;

namespace App.Composition {

    public sealed class ApplicationRoot : MonoBehaviour {

        //private readonly ISceneIdentifier homeScene = new BuiltInSceneIdentifier("Home");
        //private readonly ISceneIdentifier stageScene = new BuiltInSceneIdentifier("Stage");

        [SerializeField] SoundSettingsView _soundSettingsView;

        private SoundSettingsUseCase settingsUseCase;
        /*
       private async void Start() {

            // Repository
            var soundRepository = new PlayerPrefsSoundSettingsRepository() as ISoundSettingsRepository;

            var soundSettingsSet = await soundRepository.LoadAsync();

            // Model
            var settingsModel = new SettingsModel(soundSettingsSet);

            // UseCase
            settingsUseCase = new SoundSettingsUseCase(settingsModel, soundRepository);

            var disposable = new CompositeDisposable();

            // Presenter
            var soundPresenter = new SettingsModalPresenter(
                _soundSettingsView,
                settingsUseCase,
                disposable);
            await soundPresenter.Initialize(new SoundSettingsViewState());



            // Ý’è•ÏX‚ðŠÄŽ‹
            settingsModel.SoundsRP.Subscribe(settings => {
                var message = 
                $"[Voice] {settings.Voice.ToString()}\n" + 
                $"[BGM] {settings.Bgm.ToString()}\n" +
                $"[SE] {settings.Se.ToString()}";
                Debug.Log(message);
            });


            await UniTask.WaitForSeconds(4);
            await settingsUseCase.SaveSoundSettingsAsync();
        }
        */
        private void OnDestroy() {
        }

    }

}