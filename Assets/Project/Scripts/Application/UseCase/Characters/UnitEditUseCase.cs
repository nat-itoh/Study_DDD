using UnityEngine;
using Project.Domain.Characters.Model;

namespace Project.UseCase.Characters {

    public sealed class UnitEditUseCase {

        private readonly UnitCollection _unitCollection;


        /// <summary>
        /// コンストラクタ．
        /// </summary>
        public UnitEditUseCase(UnitCollection unitCollection) {
            _unitCollection = unitCollection;
        }

        public void AddCharacterToUnit(int unitIndex, Character character) {
            _unitCollection.Units[unitIndex].AddMember(character);
        }

        public void RemoveCharacterFromUnit(int unitIndex, CharacterId characterId) {
            _unitCollection.Units[unitIndex].RemoveMember(characterId);
        }

        public void SetActiveUnit(int index) {
            _unitCollection.SetActiveUnit(index);
        }

        public Unit GetActiveUnit() {
            return _unitCollection.ActiveUnit;
        }
    }
}
