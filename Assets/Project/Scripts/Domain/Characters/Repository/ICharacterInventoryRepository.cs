using System;
using Cysharp.Threading.Tasks;
using Project.Domain.Shared;
using Project.Domain.Characters.Model;

namespace Project.Domain.Characters.Repository {

    public interface ICharacterInventoryRepository {
        UniTask SaveAsync(CharacterInventory inventory);
        UniTask<CharacterInventory> LoadAsync();
    }
}
