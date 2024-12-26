using System.Collections.Generic;
using Project.Domain.Shared;
using Project.Domain.Characters.Model;

namespace Project.Domain.Characters.Repository {

    public interface ICharacterMasterTable : IMasterTable {

        IReadOnlyList<Character> GetAll();
        Character FindById(CharacterId id);
    }
}
