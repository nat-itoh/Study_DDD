using System;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// ���ʐݒ�D
    /// </summary>
    public sealed class SoundSettingsSet : ValueObject<SoundSettingsSet> {

        public SoundSettings Bgm { get; }
        public SoundSettings Se { get; }
        public SoundSettings Voice { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public SoundSettingsSet(SoundSettings bgm, SoundSettings se, SoundSettings voice) {
            Bgm = bgm;
            Se = se;
            Voice = voice;
        }

        /// <summary>
        /// �n�b�V���l�̎擾�D
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(Voice, Bgm, Se);
        }

        public SoundSettingsSet WithBgm(SoundSettings bgm) => new(bgm, Se, Voice);
        public SoundSettingsSet WithSe(SoundSettings se) => new(Bgm, se, Voice);
        public SoundSettingsSet WithVoice(SoundSettings voice) => new(Bgm, Se, voice);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// �l�̔�r���W�b�N�D
        /// </summary>
        protected override bool EqualsCore(SoundSettingsSet other) {
            return this.Bgm == other.Bgm
                && this.Se == other.Se
                && this.Voice == other.Voice;
        }
    }
}
