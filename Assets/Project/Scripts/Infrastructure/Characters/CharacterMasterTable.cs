using System.Collections.Generic;
using System.Linq;
using Project.Domain.Characters.Model;
using Project.Domain.Characters.Repository;

namespace Project.Infrastructure.Characters {

    public sealed class CharacterMasterTable : ICharacterMasterTable {

        private Dictionary<int, Character> _characters;


        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public CharacterMasterTable(IEnumerable<Character> characters) {
            _characters = characters.ToDictionary(c => c.Id.Value);
        }

        /// <summary>
        /// 初期化処理．
        /// </summary>
        public void Initialize() { }

        /// <summary>
        /// 全要素を取得する．
        /// </summary>
        public IReadOnlyList<Character> GetAll() {
            return _characters.Values.ToList();
        }

        /// <summary>
        /// IDで検索する．
        /// </summary>
        public Character FindById(CharacterId id) {
            return _characters.TryGetValue(id.Value, out var character) ? character : null;
        }
    }
}
