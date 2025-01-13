using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Project.Domain.Memos.Model;
using Project.Domain.Memos.Repository;
using Project.Infrastructure.SQLiteNet.Memos;
using Project.Application.Memos.UseCase;

namespace Project.Composition {

    public class Memo_TestEntry : MonoBehaviour {

        private IMemoRepository _repository;
        private MemoUseCase _usecase;

        private async void Start() {

            // Repository
            _repository = new SQLiteMemoRepository();

            // Service
            _usecase = new MemoUseCase(_repository);

        }

        private void OnDestroy() {
            _repository.Dispose();
        }
    }
}
