using System;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {
    
    /// <summary>
    /// �Q�[���v���C�ݒ�D�v���C���[�̑̌��Ɋ֘A����ݒ���Ǘ�����D
    /// </summary>
    public sealed class GameplaySettings : ValueObject<GameplaySettings> {

        /// <summary>
        /// ��Փx���x���D0: Easy, 1: Normal, 2: Hard
        /// </summary>
        public int DifficultyLevel { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public GameplaySettings(int difficultyLevel) {
            DifficultyLevel = difficultyLevel;
        }

        /// <summary>
        /// �n�b�V���l�̎擾�D
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(DifficultyLevel);
        }

        /// <summary>
        /// �l�̍X�V���\�b�h�D
        /// </summary>
        public GameplaySettings WithDifficultyLevel(int difficultyLevel) => new(difficultyLevel);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// �l�̔�r���W�b�N�D
        /// </summary>
        protected override bool EqualsCore(GameplaySettings other) {
            return DifficultyLevel == other.DifficultyLevel;
        }
    }
}
