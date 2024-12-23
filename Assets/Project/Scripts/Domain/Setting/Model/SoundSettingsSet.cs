using System;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// 音量設定．
    /// </summary>
    public sealed class SoundSettingsSet : ValueObject<SoundSettingsSet> {

        public SoundSettings Voice { get; }
        public SoundSettings Bgm { get; }
        public SoundSettings Se { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public SoundSettingsSet(SoundSettings voice, SoundSettings bgm, SoundSettings se) {
            Voice = voice;
            Bgm = bgm;
            Se = se;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Voice, Bgm, Se);
        }

        public SoundSettingsSet WithVoice(SoundSettings voice) => new(voice, Bgm, Se);
        public SoundSettingsSet WithBgm(SoundSettings bgm) => new(Voice, bgm, Se);
        public SoundSettingsSet WithSe(SoundSettings se) => new(Voice, Bgm, se);


        /// ----------------------------------------------------------------------------
        // Protected Method

        protected override bool EqualsCore(SoundSettingsSet other) {
            return this.Voice == other.Voice
                && this.Bgm == other.Bgm
                && this.Se == other.Se;
        }
    }
}
