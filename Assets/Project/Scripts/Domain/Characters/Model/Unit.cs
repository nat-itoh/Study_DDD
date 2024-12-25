using System.Collections.Generic;
using System.Linq;
using Project.Domain.Shared;

namespace Project.Domain.Characters.Model {

    public sealed class Unit {

        private const int MaxMembers = 3;

        private readonly List<Character> _members;
        
        public IReadOnlyList<Character> Members => _members;
        public Character Leader => _members.FirstOrDefault();


        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public Unit(IEnumerable<Character> members) {
            _members = members.Take(MaxMembers).ToList();
        }

        /// <summary>
        /// メンバーを追加する．
        /// </summary>
        public void AddMember(Character character) {
            if (_members.Count >= MaxMembers) {
                throw new System.InvalidOperationException("ユニットには最大3人までしか追加できません。");
            }
            _members.Add(character);
        }

        /// <summary>
        /// メンバーを削除する．
        /// </summary>
        public void RemoveMember(CharacterId id) {
            _members.RemoveAll(c => c.Id == id);
        }
    }
}
