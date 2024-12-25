using System;
using Cysharp.Threading.Tasks;
using UniRx;
//using Demo.Core.Scripts.Presentation.Shared;
using Project.Domain.Setting.Model;
using Project.UseCase.Setting;
using Project.View.Setting;
using Demo.Subsystem.PresentationFramework;

namespace Project.Presentation.Setting {
    public sealed class SettingsModalPresenter {

        private readonly SoundSettingsUseCase _useCase;
        private readonly SoundSettingsView _view;
        private bool _dirty;

        private CompositeDisposable _disposables;

        public SettingsModalPresenter(SoundSettingsView view, SoundSettingsUseCase useCase, CompositeDisposable disposable) {
            _view = view;
            _useCase = useCase;
            _disposables = disposable;
        }

        public async UniTask Initialize(SoundSettingsViewState viewState) {
            // Update models.
            await _useCase.LoadSoundSettingsAsync();
            var model = _useCase.Model;

            await _view.InitializeAsync(viewState);

            // Observe changes of models.
            model.SoundsRP
                .Subscribe(x => {
                    SetBgmSettingsViewState(viewState, x.Bgm.Volume, x.Bgm.Muted);
                    SetSeSettingsViewState(viewState, x.Se.Volume, x.Se.Muted);
                    SetVoiceSettingsViewState(viewState, x.Voice.Volume, x.Voice.Muted);
                })
                .AddTo(_disposables);

            // Observe changes of view state.
            Observable.Merge(
                    viewState.IsVoiceEnabledRP.AsUnitObservable(),
                    viewState.IsBgmEnabledRP.AsUnitObservable(),
                    viewState.IsSeEnabledRP.AsUnitObservable(),
                    viewState.VoiceVolumeRP.AsUnitObservable(),
                    viewState.SeVolumeRP.AsUnitObservable(),
                    viewState.BgmVolumeRP.AsUnitObservable())
                // “K“–‚ÈŠÔˆø‚«
                .Throttle(TimeSpan.FromSeconds(0.1f))
                .Subscribe(_ => ApplyToModel(viewState))
                .AddTo(_disposables);

            //viewState.CloseButtonClicked
            //    .Subscribe(_ => TransitionService.PopCommandExecuted())
            //    .AddTo(this);
            //viewState.LockedButtonClicked
            //    .Subscribe(_ => TransitionService.SettingsModalLockedButtonClicked())
            //    .AddTo(this);
        }

        private void SetBgmSettingsViewState(SoundSettingsViewState viewState, float volume, bool isMuted) {
            viewState.BgmVolumeRP.Value = volume;
            viewState.IsBgmEnabledRP.Value = !isMuted;
        }

        private void SetSeSettingsViewState(SoundSettingsViewState viewState, float volume, bool isMuted) {
            viewState.SeVolumeRP.Value = volume;
            viewState.IsSeEnabledRP.Value = !isMuted;
        }

        private void SetVoiceSettingsViewState(SoundSettingsViewState viewState, float volume, bool isMuted) {
            viewState.VoiceVolumeRP.Value = volume;
            viewState.IsVoiceEnabledRP.Value = !isMuted;
        }

        private void ApplyToModel(SoundSettingsViewState viewState) {
            var bgm = new SoundSettings(viewState.BgmVolumeRP.Value, !viewState.IsBgmEnabledRP.Value);
            var se = new SoundSettings(viewState.SeVolumeRP.Value, !viewState.IsSeEnabledRP.Value);
            var voice = new SoundSettings(viewState.VoiceVolumeRP.Value, !viewState.IsVoiceEnabledRP.Value);
            _useCase.UpdateSoundSettings(new SoundSettingsSet(bgm, se, voice));
        }


        //private async UniTask ViewWillExit(SettingsModal view, SettingsViewState viewState) {
        //    if (!_dirty)
        //        return;

        //    // Save sound settings
        //    await _useCase.SaveSoundSettingsAsync();
        //}
    }
}
