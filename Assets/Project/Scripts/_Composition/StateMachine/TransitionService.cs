using UnityEngine;
using Bg.UniTaskStateMachine;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using UnityEngine.Assertions;

namespace Project.Composition {

    public partial class TransitionService : MonoBehaviour {

        [SerializeField] Bg.UniTaskStateMachine.StateMachineBehaviour _stateMachine;

        void Start() {
            Debug.Log("FMS Start");

            foreach (var state in gameObject.GetComponents<State>()) {
                state.StateMachine = _stateMachine.StateMachine;
            }

            _stateMachine.StateMachine.Start();
        }

        private void OnDestroy() {
            _stateMachine.StateMachine.Stop();
        }


        public abstract class State : BaseStateComponent {

            public static PageContainer PageContainer => PageContainer.Find("MainPageContainer");

            /// <summary>
            /// ステートマシン．<see cref="BaseStateComponent.baseNode"/>がnullになるので，手動で設定．
            /// </summary>
            public StateMachine StateMachine { get; internal set; }

            protected void RequestTransition(string transitionId) {

                if (string.IsNullOrEmpty(transitionId)) {
                    Debug.LogError("Transition ID is null or empty.");
                    return;
                }

                //
                StateMachine.TriggerNextTransition(transitionId);
            }
        }

        public static class Key {
            public static readonly string Top_to_Home = "Top_to_Home";
            public static readonly string Home_to_Settings = "Home_to_Settings";
            public static readonly string Settings_to_Home = "Settings_to_Home";
        }
    }
}
