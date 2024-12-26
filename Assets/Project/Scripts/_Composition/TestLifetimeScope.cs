using VContainer;
using VContainer.Unity;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace Project.Composition {

    public class TestLifetimeScope : LifetimeScope {

        [SerializeField] ModalContainer _modalContainer;


        protected override void Configure(IContainerBuilder builder){

            Debug.Log("Configure");
            // ModalContainer‚ð“o˜^
            builder.RegisterComponent(_modalContainer);

            // 
            builder.RegisterEntryPoint<MainScreenModalManager>();
        }
    }
}
