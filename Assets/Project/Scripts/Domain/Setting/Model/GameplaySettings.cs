using System;
using Project.Domain.Shared;

namespace Project.Domain.Setting.Model {
    
    /// <summary>
    /// ゲームプレイ設定．プレイヤーの体験に関連する設定を管理する．
    /// </summary>
    public sealed class GameplaySettings : ValueObject<GameplaySettings> {

        /// <summary>
        /// 難易度レベル．0: Easy, 1: Normal, 2: Hard
        /// </summary>
        public int DifficultyLevel { get; private set; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public GameplaySettings(int difficultyLevel) {
            DifficultyLevel = difficultyLevel;
        }

        /// <summary>
        /// ハッシュ値の取得．
        /// </summary>
        public override int GetHashCode() {
            return HashCode.Combine(DifficultyLevel);
        }

        /// <summary>
        /// 値の更新メソッド．
        /// </summary>
        public GameplaySettings WithDifficultyLevel(int difficultyLevel) => new(difficultyLevel);


        /// ----------------------------------------------------------------------------
        // Protected Method

        /// <summary>
        /// 値の比較ロジック．
        /// </summary>
        protected override bool EqualsCore(GameplaySettings other) {
            return DifficultyLevel == other.DifficultyLevel;
        }
    }
}
