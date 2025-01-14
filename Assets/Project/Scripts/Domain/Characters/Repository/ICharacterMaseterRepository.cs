using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.Domain.Shared;
using Project.Domain.Characters.Model;

namespace Project.Domain.Characters.Repository {

    public interface ICharacterMaseterRepository : IMasterRepository {

        UniTask<ICharacterMasterTable> FetchTableAsync();
    }
}
