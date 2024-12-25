using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using MackySoft.Navigathena.SceneManagement;

namespace BmiApp.Composition {

    public sealed class StageSceneEntryPoint : SceneEntryPointBase {


        protected override UniTask OnEnter(ISceneDataReader reader, CancellationToken cancellationToken) {
            Debug.Log("(Stage) Enter");
            return UniTask.CompletedTask;
        }

        protected override UniTask OnExit(ISceneDataWriter writer, CancellationToken cancellationToken) {
            Debug.Log("(Stage) Exit");
            return UniTask.CompletedTask;
        }
    }
}
