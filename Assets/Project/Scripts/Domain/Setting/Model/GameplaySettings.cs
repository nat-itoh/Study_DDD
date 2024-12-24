using System;
using UniRx;

namespace Project.Domain.Setting.Model {
    
    /// <summary>
    /// �Q�[���v���C�ݒ�D�v���C���[�̑̌��Ɋ֘A����ݒ���Ǘ�����D
    /// </summary>
    public sealed class GameplaySettings : IDisposable{

        private readonly Subject<ValueChangedEvent> _valueChangedSubject = new();

        // 0: Easy, 1: Normal, 2: Hard
        public int DifficultyLevel { get; private set; } 

        /// <summary>
        /// �I�������D
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
