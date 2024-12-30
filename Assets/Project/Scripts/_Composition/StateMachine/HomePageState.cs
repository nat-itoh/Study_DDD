using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using Bg.UniTaskStateMachine;
using Project.View;
using Project.Foundation;

namespace Project.Composition.UI {

    public sealed class HomePageState : TransitionService.State {


        public override void Init(BaseNode baseNode) {
            Debug.Log("[Home] Init");
            
        }

        public override async UniTask OnEnter(CancellationToken ct = default) {
            Debug.Log("[Home] Enter");

            await PageContainer.Push<PageB>(ResourceKey.UI.PageB, true,
                onLoad: x => {
                    var page = x.page;
                    page.button.OnClickAsObservable()
                        .Subscribe(_ => RequestTransition(TransitionService.Key.Home_to_Settings))
                        .AddTo(this);
                });

            await UniTask.CompletedTask;
        }

        public override async UniTask OnExit(CancellationToken ct = default) {
            Debug.Log("[Home] Exit");

            await UniTask.CompletedTask;
        }

    }
}
