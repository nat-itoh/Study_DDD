using System;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using VContainer;
using VContainer.Unity;

namespace Project.Composition {

    public sealed class VContainerModalCallbackRegister : IModalContainerCallbackReceiver {

        private IObjectResolver _resolver;


        /// ----------------------------------------------------------------------------
        // Public Method

        public VContainerModalCallbackRegister(IObjectResolver resolver) {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
        }

        void IModalContainerCallbackReceiver.BeforePush(Modal enterModal, Modal exitModal) {
            Debug.Log("[Modal Register] Before Push");

            _resolver.InjectGameObject(enterModal.gameObject);
        }

        void IModalContainerCallbackReceiver.AfterPush(Modal enterModal, Modal exitModal) {
            Debug.Log("[Modal Register] After Push");
        
        }

        void IModalContainerCallbackReceiver.BeforePop(Modal enterModal, Modal exitModal) {
            Debug.Log("[Modal Register] Before Pop");
        
        }
        
        void IModalContainerCallbackReceiver.AfterPop(Modal enterModal, Modal exitModal) {
            Debug.Log("[Modal Register] After Pop");
        }
    }
}
