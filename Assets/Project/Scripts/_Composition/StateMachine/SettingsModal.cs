using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Bg.UniTaskStateMachine;
using Project.Foundation;
using Project.View;

namespace Project.Composition.UI {

    public sealed class SettingsModalState : TransitionService.State {

        public override async UniTask OnEnter(CancellationToken ct = default) {
            Debug.Log("[Settings] Enter");

            await PageContainer.Push<PageC>(ResourceKey.UI.PageC, true,
                onLoad: x => {
                    var page = x.page;
                    page.button.OnClickAsObservable()
                        .Subscribe(_ => RequestTransition(TransitionService.Key.Settings_to_Home))
                        .AddTo(this);
                });

            await UniTask.CompletedTask;
        }

        public override async UniTask OnExit(CancellationToken ct = default) {
            Debug.Log("[Settings] Exit");

            await PageContainer.Pop(true);

            await UniTask.CompletedTask;
        }
    }
}
