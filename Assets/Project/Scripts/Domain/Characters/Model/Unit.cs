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
        /// �R���X�g���N�^�D
        /// </summary>
        public Unit(IEnumerable<Character> members) {
            _members = members.Take(MaxMembers).ToList();
        }

        /// <summary>
        /// �����o�[��ǉ�����D
        /// </summary>
        public void AddMember(Character character) {
            if (_members.Count >= MaxMembers) {
                throw new System.InvalidOperationException("���j�b�g�ɂ͍ő�3�l�܂ł����ǉ��ł��܂���B");
            }
            _members.Add(character);
        }

        /// <summary>
        /// �����o�[���폜����D
        /// </summary>
        public void RemoveMember(CharacterId id) {
            _members.RemoveAll(c => c.Id == id);
        }
    }
}
