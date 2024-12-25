using UnityEngine;
using Project.Domain.Shared;

namespace Project.Domain.Characters.Model {

    /// <summary>
    /// キャラクタを表すEntity．
    /// </summary>
    public sealed class Character {

        /// <summary>
        /// ID．
        /// </summary>
        public CharacterId Id { get; }

        /// <summary>
        /// 名称．
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// レア度．
        /// </summary>
        public Rarity Rarity { get; }

        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public Character(CharacterId id, string name, Rarity rarity) {
            Id = id;
            Name = name;
            Rarity = rarity;
        }
    }
}
