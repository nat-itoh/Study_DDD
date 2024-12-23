using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;

namespace Project.Infrastructure.Setting {

    public class PlayerPrefsSoundSettingsRepository : ISoundSettingsRepository {

        // Key
        private const string VoiceVolumeKey = "VoiceVolume";
        private const string VoiceMutedKey = "VoiceMuted";
        private const string BgmVolumeKey = "BgmVolume";
        private const string BgmMutedKey = "BgmMuted";
        private const string SeVolumeKey = "SeVolume";
        private const string SeMutedKey = "SeMuted";


        private static float VoiceVolume {
            get => PlayerPrefs.GetFloat(VoiceVolumeKey, 1.0f);
            set => PlayerPrefs.SetFloat(VoiceVolumeKey, value);
        }

        private static float BgmVolume {
            get => PlayerPrefs.GetFloat(BgmVolumeKey, 1.0f);
            set => PlayerPrefs.SetFloat(BgmVolumeKey, value);
        }

        private static float SeVolume {
            get => PlayerPrefs.GetFloat(SeVolumeKey, 1.0f);
            set => PlayerPrefs.SetFloat(SeVolumeKey, value);
        }

        private static bool IsVoiceMuted {
            get => PlayerPrefs.GetInt(VoiceMutedKey, 0) == 1;
            set => PlayerPrefs.SetInt(VoiceMutedKey, value ? 1 : 0);
        }

        private static bool IsBgmMuted {
            get => PlayerPrefs.GetInt(BgmMutedKey, 0) == 1;
            set => PlayerPrefs.SetInt(BgmMutedKey, value ? 1 : 0);
        }

        private static bool IsSeMuted {
            get => PlayerPrefs.GetInt(SeMutedKey, 0) == 1;
            set => PlayerPrefs.SetInt(SeMutedKey, value ? 1 : 0);
        }


        /// <summary>
        /// 非同期で設定値を読み込む．
        /// </summary>
        public UniTask<SoundSettingsSet> LoadAsync() {

            var voice = new SoundSettings(VoiceVolume, IsVoiceMuted);
            var bgm = new SoundSettings(BgmVolume, IsBgmMuted);
            var se = new SoundSettings(SeVolume, IsSeMuted);

            return UniTask.FromResult(new SoundSettingsSet(voice, bgm, se));
        }

        /// <summary>
        /// 非同期で設定値を保存する．
        /// </summary>
        public UniTask SaveAsync(SoundSettingsSet soundSettingsSet) {

            VoiceVolume = soundSettingsSet.Voice.Volume;
            IsVoiceMuted = soundSettingsSet.Voice.Muted;

            BgmVolume = soundSettingsSet.Bgm.Volume;
            IsBgmMuted = soundSettingsSet.Bgm.Muted;
            
            SeVolume = soundSettingsSet.Se.Volume;
            IsSeMuted = soundSettingsSet.Se.Muted;

            return UniTask.CompletedTask;
        }
    }
}
