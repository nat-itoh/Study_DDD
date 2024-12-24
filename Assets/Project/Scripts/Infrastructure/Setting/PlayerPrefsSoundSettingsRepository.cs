using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;

namespace Project.Infrastructure.Setting {

    public class PlayerPrefsSoundSettingsRepository : ISoundSettingsRepository {

        // �L�[�̊Ǘ�
        private static class Keys {
            public const string VoiceVolume = "VoiceVolume";
            public const string VoiceMuted = "VoiceMuted";
            public const string BgmVolume = "BgmVolume";
            public const string BgmMuted = "BgmMuted";
            public const string SeVolume = "SeVolume";
            public const string SeMuted = "SeMuted";
        }

        private static float VoiceVolume {
            get => PlayerPrefs.GetFloat(Keys.VoiceVolume, 1.0f);
            set => PlayerPrefs.SetFloat(Keys.VoiceVolume, value);
        }

        private static bool IsVoiceMuted {
            get => PlayerPrefs.GetInt(Keys.VoiceMuted, 0) == 1;
            set => PlayerPrefs.SetInt(Keys.VoiceMuted, value ? 1 : 0);
        }

        private static float BgmVolume {
            get => PlayerPrefs.GetFloat(Keys.BgmVolume, 1.0f);
            set => PlayerPrefs.SetFloat(Keys.BgmVolume, value);
        }

        private static bool IsBgmMuted {
            get => PlayerPrefs.GetInt(Keys.BgmMuted, 0) == 1;
            set => PlayerPrefs.SetInt(Keys.BgmMuted, value ? 1 : 0);
        }

        private static float SeVolume {
            get => PlayerPrefs.GetFloat(Keys.SeVolume, 1.0f);
            set => PlayerPrefs.SetFloat(Keys.SeVolume, value);
        }

        private static bool IsSeMuted {
            get => PlayerPrefs.GetInt(Keys.SeMuted, 0) == 1;
            set => PlayerPrefs.SetInt(Keys.SeMuted, value ? 1 : 0);
        }


        /// <summary>
        /// �񓯊��Őݒ�l��ǂݍ��ށD
        /// </summary>
        public UniTask<SoundSettingsSet> LoadAsync() {

            var bgm = new SoundSettings(BgmVolume, IsBgmMuted);
            var se = new SoundSettings(SeVolume, IsSeMuted);
            var voice = new SoundSettings(VoiceVolume, IsVoiceMuted);

            return UniTask.FromResult(new SoundSettingsSet(bgm, se, voice));
        }

        /// <summary>
        /// �񓯊��Őݒ�l��ۑ�����D
        /// </summary>
        public UniTask SaveAsync(SoundSettingsSet sounds) {

            BgmVolume = sounds.Bgm.Volume;
            IsBgmMuted = sounds.Bgm.Muted;
            
            SeVolume = sounds.Se.Volume;
            IsSeMuted = sounds.Se.Muted;
            
            VoiceVolume = sounds.Voice.Volume;
            IsVoiceMuted = sounds.Voice.Muted;

            return UniTask.CompletedTask;
        }
    }
}
