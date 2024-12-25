using UnityEngine;
using Project.Domain.Characters.Model;
using System.Collections.Generic;

namespace Project.UseCase.Characters {

    public sealed class CharacterInventoryUseCase {

        private readonly CharacterInventory _inventory;


        public CharacterInventoryUseCase(CharacterInventory inventory) {
            _inventory = inventory;
        }


        public IReadOnlyList<Character> GetCharacters() {
            return _inventory.Characters;
        }

        public void AddCharacter(Character character) {
            _inventory.AddCharacter(character);
        }

        public void RemoveCharacter(CharacterId id) {
            _inventory.RemoveCharacter(id);
        }
    }
}
