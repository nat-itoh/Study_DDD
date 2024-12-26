using UnityEngine;
using Project.Domain.Shared;

namespace Project.Domain.Characters.Model {

    /// <summary>
    /// �L�����N�^��\��Entity�D
    /// </summary>
    public sealed class Character {

        /// <summary>
        /// ID�D
        /// </summary>
        public CharacterId Id { get; }

        /// <summary>
        /// ���́D
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// ���A�x�D
        /// </summary>
        public Rarity Rarity { get; }


        /// ----------------------------------------------------------------------------
        // Public Method

        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public Character(CharacterId id, string name, Rarity rarity) {
            Id = id;
            Name = name;
            Rarity = rarity;
        }

        public override string ToString() {
            return $"id: {Id.ToString()}, name: {Name}";
        }
    }
}
