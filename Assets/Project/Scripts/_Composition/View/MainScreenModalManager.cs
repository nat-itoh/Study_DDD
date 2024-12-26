using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using VContainer;
using VContainer.Unity;

namespace Project.Composition {

    public class MainScreenModalManager : IInitializable {

        private ModalContainer _modalContainer;
        private IObjectResolver _resolver;

        [Inject]
        public MainScreenModalManager(ModalContainer container, IObjectResolver resolver) {
            _modalContainer = container;
            _resolver = resolver;
        }

        async void IInitializable.Initialize() {

            Debug.Log("Initialize");
            _modalContainer.AddCallbackReceiver(new VContainerModalCallbackRegister(_resolver));

            await UniTask.WaitForSeconds(1);

            await _modalContainer.Push("TestModal", true);
        }


    }
}
