using Demo.Subsystem.PresentationFramework;
using UniRx;

namespace Project.View.Setting {

    public sealed class SoundSettingsViewState : AppViewState, 
        ISoundSettingsState {

        private readonly ReactiveProperty<float> _bgmVolumeRP = new();
        private readonly ReactiveProperty<bool> _isBgmEnabledRP = new();
        private readonly ReactiveProperty<bool> _isSeEnabledRP = new();
        private readonly ReactiveProperty<bool> _isVoiceEnabledRP = new();
        private readonly ReactiveProperty<float> _seVolumeRP = new();
        private readonly ReactiveProperty<float> _voiceVolumeRP = new();

        public IReactiveProperty<float> VoiceVolumeRP => _voiceVolumeRP;
        public IReactiveProperty<float> BgmVolumeRP => _bgmVolumeRP;
        public IReactiveProperty<float> SeVolumeRP => _seVolumeRP;
        public IReactiveProperty<bool> IsVoiceEnabledRP => _isVoiceEnabledRP;
        public IReactiveProperty<bool> IsBgmEnabledRP => _isBgmEnabledRP;
        public IReactiveProperty<bool> IsSeEnabledRP => _isSeEnabledRP;


        protected override void DisposeInternal() {
            _voiceVolumeRP.Dispose();
            _bgmVolumeRP.Dispose();
            _seVolumeRP.Dispose();
            _isVoiceEnabledRP.Dispose();
            _isBgmEnabledRP.Dispose();
            _isSeEnabledRP.Dispose();
        }
    }

    internal interface ISoundSettingsState { }
}
