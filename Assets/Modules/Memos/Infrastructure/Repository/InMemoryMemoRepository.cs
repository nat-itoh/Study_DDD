using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Project.Domain.Memos.Model;
using Project.Domain.Memos.Repository;

namespace Project.Infrastructure.Memos {

    public sealed class InMemoryMemoRepository : IMemoRepository {

        private readonly Dictionary<Guid, Memo> _store = new();


        public UniTask SaveAsync(Memo memo) {
            _store[memo.Id] = memo;
            return UniTask.CompletedTask;
        }

        public UniTask<IEnumerable<Memo>> GetAllAsync() {
            return UniTask.FromResult(_store.Values.AsEnumerable());
        }

        public UniTask<Memo> FindByIdAsync(Guid id) {
            _store.TryGetValue(id, out var memo);
            return UniTask.FromResult(memo);
        }

        public UniTask DeleteAsync(Guid id) {
            _store.Remove(id);
            return UniTask.CompletedTask;
        }

    }
}
