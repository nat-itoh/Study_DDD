using Cysharp.Threading.Tasks;
using Demo.Subsystem.PresentationFramework;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Project.View.Utils;

namespace Project.View.Setting {

    public sealed class SoundSettingsView : AppView<SoundSettingsViewState> {

        // Bgm
        public Slider bgmSlider;
        public Toggle bgmToggle;
        
        // Se
        public Slider seSlider;
        public Toggle seToggle;
        
        // Voive
        public Slider voiceSlider;
        public Toggle voiceToggle;


        /// <summary>
        /// ‰Šú‰»ˆ—D
        /// </summary>
        protected override UniTask Initialize(SoundSettingsViewState viewState) {

            // 
            viewState.BgmVolumeRP.Subscribe(x => bgmSlider.value = x).AddTo(this);
            viewState.SeVolumeRP.Subscribe(x => seSlider.value = x).AddTo(this);
            viewState.VoiceVolumeRP.Subscribe(x => voiceSlider.value = x).AddTo(this);
            viewState.IsBgmEnabledRP.Subscribe(x => bgmToggle.isOn = x).AddTo(this);
            viewState.IsSeEnabledRP.Subscribe(x => seToggle.isOn = x).AddTo(this);
            viewState.IsVoiceEnabledRP.Subscribe(x => voiceToggle.isOn = x).AddTo(this);

            // Intarctable
            viewState.IsBgmEnabledRP.Subscribe(x => bgmSlider.interactable = x).AddTo(this);
            viewState.IsSeEnabledRP.Subscribe(x => seSlider.interactable = x).AddTo(this);
            viewState.IsVoiceEnabledRP.Subscribe(x => voiceSlider.interactable = x).AddTo(this);

            // 
            bgmSlider.SetOnValueChangedDestination(x => viewState.BgmVolumeRP.Value = x).AddTo(this);
            seSlider.SetOnValueChangedDestination(x => viewState.SeVolumeRP.Value = x).AddTo(this);
            voiceSlider.SetOnValueChangedDestination(x => viewState.VoiceVolumeRP.Value = x).AddTo(this);
            bgmToggle.SetOnValueChangedDestination(x => viewState.IsBgmEnabledRP.Value = x).AddTo(this);
            seToggle.SetOnValueChangedDestination(x => viewState.IsSeEnabledRP.Value = x).AddTo(this);
            voiceToggle.SetOnValueChangedDestination(x => viewState.IsVoiceEnabledRP.Value = x).AddTo(this);

            return UniTask.CompletedTask;
        }
    }
}
