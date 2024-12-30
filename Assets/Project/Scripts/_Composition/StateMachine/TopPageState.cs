using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Bg.UniTaskStateMachine;
using Project.Foundation;
using Project.View;
using UnityEngine.Assertions;

namespace Project.Composition.UI {

    public sealed class TopPageState : TransitionService.State {

        public override void Init(BaseNode baseNode) {
            Debug.Log("[Top] Init");

        }

        public override async UniTask OnEnter(CancellationToken ct = default) {
            Debug.Log("[Top] Enter");

            await PageContainer.Push<PageA>(ResourceKey.UI.PageA, true,
                onLoad: x => {
                    var page = x.page;
                    page.button.OnClickAsObservable()
                        .Subscribe(_ => RequestTransition(TransitionService.Key.Top_to_Home))
                        .AddTo(this);
                });

            await UniTask.CompletedTask;
        }

        public override async UniTask OnExit(CancellationToken ct = default) {
            Debug.Log("[Top] Exit");

            await UniTask.CompletedTask;
        }

    }
}
