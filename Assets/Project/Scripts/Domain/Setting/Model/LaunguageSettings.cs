using System;
using UniRx;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {

    /// <summary>
    /// ����ݒ�D�����n��Ɋ֘A����ݒ���Ǘ�����D
    /// </summary>
    public sealed class LaunguageSettings : ValueObject<LaunguageSettings> {

        /// <summary>
        /// ����R�[�h�D
        /// �ie.g., "en-US", "ja-JP"�j
        /// </summary>
        public string LanguageCode { get; private set; }

        /// <summary>
        /// �n��R�[�h�D
        /// �ie.g., "US", "JP"�j
        /// </summary>
        public string RegionCode { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public LaunguageSettings() {

        }

        /// <summary>
        /// �n�b�V���l�̎擾�D
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(LanguageCode, RegionCode);
        }


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// �l�̔�r���W�b�N�D
        /// </summary>
        protected override bool EqualsCore(LaunguageSettings other) {
            return this.LanguageCode == other.LanguageCode
                && this.RegionCode == other.RegionCode;
        }
    }
}
