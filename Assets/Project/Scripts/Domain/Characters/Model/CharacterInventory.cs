using System.Collections.Generic;
using Project.Domain.Shared;

namespace Project.Domain.Characters.Model {

    /// <summary>
    /// �L�����N�^���i�[����C���x���g���D
    /// </summary>
    public sealed class CharacterInventory {

        private readonly List<Character> _characters = new();
        public IReadOnlyList<Character> Characters => _characters;


        /// <summary>
        /// 
        /// </summary>
        internal void AddCharacter(Character character) {
            _characters.Add(character);
        }

        /// <summary>
        /// 
        /// </summary>
        internal void RemoveCharacter(CharacterId id) {
            _characters.RemoveAll(c => c.Id == id);
        }
    }
}
