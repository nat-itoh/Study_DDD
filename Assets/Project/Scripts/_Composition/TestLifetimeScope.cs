using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace Project.Composition {

    public class TestLifetimeScope : LifetimeScope {

        protected override void Configure(IContainerBuilder builder){

            Debug.Log("Configure");
        }
    }
}
