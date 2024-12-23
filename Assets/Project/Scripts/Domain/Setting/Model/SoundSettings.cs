using System;
using UniRx;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// 音量設定．
    /// </summary>
    public sealed class SoundSettings : ValueObject<SoundSettings> {

        /// <summary>
        /// 音量．
        /// </summary>
        public float Volume { get; private set; }
        
        /// <summary>
        /// ミュート状態．
        /// </summary>
        public bool Muted { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public SoundSettings(float volume, bool muted) {
            Volume = volume;
            Muted = muted;
        }

        /// <summary>
        /// ハッシュ値の取得．
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
