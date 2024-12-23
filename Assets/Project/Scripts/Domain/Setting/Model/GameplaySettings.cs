using System;
using UniRx;

namespace Project.Domain.Setting.Model {
    
    /// <summary>
    /// ゲームプレイ設定．プレイヤーの体験に関連する設定を管理する．
    /// </summary>
    public sealed class GameplaySettings : IDisposable{

        private readonly Subject<ValueChangedEvent> _valueChangedSubject = new();

        // 0: Easy, 1: Normal, 2: Hard
        public int DifficultyLevel { get; private set; } 

        /// <summary>
        /// 終了処理．
        /// </summary>
        public void Dispose() {
            _valueChangedSubject.Dispose();
        }


        public readonly struct ValueChangedEvent {
            public ValueChangedEvent(int difficultyLevel) {
                DifficultyLevel = difficultyLevel;
            }

            public int DifficultyLevel { get; }
        }
    }
}
