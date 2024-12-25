using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using MackySoft.Navigathena.SceneManagement;

namespace BmiApp.Composition {

    public sealed class HomeSceneEntryPoint : SceneEntryPointBase {

        protected override UniTask OnEnter(ISceneDataReader reader, CancellationToken cancellationToken) {
            Debug.Log("(Home) Enter");  
            return UniTask.CompletedTask;
        }

        protected override UniTask OnExit(ISceneDataWriter writer, CancellationToken cancellationToken) {
            Debug.Log("(Home) Exit");  
            return UniTask.CompletedTask;
        }

        private void Awake() => Debug.Log("(Home) Awake");  
        private void Start() => Debug.Log("(Home) Strt");  
        private void OnDestroy() => Debug.Log("(Home) OnDestroy"); 

    }
}
