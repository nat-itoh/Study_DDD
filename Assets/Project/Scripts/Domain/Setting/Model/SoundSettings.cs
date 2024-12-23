using System;
using UniRx;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// ���ʐݒ�D
    /// </summary>
    public sealed class SoundSettings : ValueObject<SoundSettings> {

        /// <summary>
        /// ���ʁD
        /// </summary>
        public float Volume { get; private set; }
        
        /// <summary>
        /// �~���[�g��ԁD
        /// </summary>
        public bool Muted { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public SoundSettings(float volume, bool muted) {
            Volume = volume;
            Muted = muted;
        }

        /// <summary>
        /// �n�b�V���l�̎擾�D
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(Volume, Muted);
        }

        public SoundSettings WithVolume(float volume) => new (volume, Muted);
        public SoundSettings WithMuted(bool muted) => new (Volume, muted);


        /// ----------------------------------------------------------------------------
        // Protected Method

        protected override bool EqualsCore(SoundSettings other) {
            return this.Volume == other.Volume 
                && this.Muted == other.Muted;
        }
    }
}
