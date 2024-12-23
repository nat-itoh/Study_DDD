using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Project.Domain.Setting.Model;
using Project.Domain.Setting.Repository;

namespace Project.Infrastructure.Setting {

    public class PlayerPrefsSoundSettingsRepository : ISoundSettingsRepository {

        // キーの管理
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
