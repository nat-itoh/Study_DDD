using VContainer;
using VContainer.Unity;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;

using Project.Domain.Characters.Repository;
using Project.Infrastructure.Characters;

namespace Project.Composition {

    public class TestLifetimeScope : LifetimeScope {

        [SerializeField] ModalContainer _modalContainer;


        protected async override void Configure(IContainerBuilder builder){

            Debug.Log("Configure");
            // ModalContainer‚ð“o˜^
            builder.RegisterComponent(_modalContainer);

            // 
            builder.RegisterEntryPoint<MainScreenModalManager>();



            var repository = new CharacterMasterRepository();
            var table =  await repository.FetchTableAsync();

            foreach(var item in table.GetAll()) {
                Debug.Log(item);
            }
        }
    }
}
