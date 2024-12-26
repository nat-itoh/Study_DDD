using System.Collections.Generic;
using System.Linq;
using Project.Domain.Characters.Model;
using Project.Domain.Characters.Repository;

namespace Project.Infrastructure.Characters {

    public sealed class CharacterMasterTable : ICharacterMasterTable {

        private Dictionary<int, Character> _characters;


        /// <summary>
        /// �R���X�g���N�^�D
        /// </summary>
        public CharacterMasterTable(IEnumerable<Character> characters) {
            _characters = characters.ToDictionary(c => c.Id.Value);
        }

        /// <summary>
        /// �����������D
        /// </summary>
        public void Initialize() {
            
        }

        /// <summary>
        /// �S�v�f���擾����D
        /// </summary>
        public IReadOnlyList<Character> GetAll() {
            return _characters.Values.ToList();
        }

        /// <summary>
        /// ID�Ō�������D
        /// </summary>
        public Character FindById(CharacterId id) {
            return _characters.TryGetValue(id.Value, out var character) ? character : null;
        }
    }
}
