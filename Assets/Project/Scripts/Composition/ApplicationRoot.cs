using UnityEngine;
using MackySoft.Navigathena.SceneManagement;
using Cysharp.Threading.Tasks;


namespace App.Composition {

    public sealed class ApplicationRoot : MonoBehaviour {


        //private readonly ISceneIdentifier homeScene = new BuiltInSceneIdentifier("Home");
        //private readonly ISceneIdentifier stageScene = new BuiltInSceneIdentifier("Stage");

        private async void Start() {

            await UniTask.Yield();

            // Data access
            //var dataStore = new TemporaryHistoryDataStore() as IHistoryDataStore;





            //await GlobalSceneNavigator.Instance.Push(homeScene);
            
        }



        //public void Update() {

        //    if (Input.GetKeyDown(KeyCode.Return)) {
        //        GlobalSceneNavigator.Instance.Replace(homeScene).Forget();
        //    } 
        //    if (Input.GetKeyDown(KeyCode.Space)) {
        //        GlobalSceneNavigator.Instance.Replace(stageScene).Forget();
        //    }

        //}
    }

}