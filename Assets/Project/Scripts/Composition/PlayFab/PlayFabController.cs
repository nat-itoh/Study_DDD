using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace BmiApp.Composition {

    public class PlayFabController : MonoBehaviour {


        private void Start() {


            PlayFabAuthService.Instance.Authenticate(Authtypes.Silent);

            //var rewuest = new LoginWithCustomIDRequest { CustomId = "GEttingStartedGuid", CreateAccount = true };
            //PlayFabClientAPI.LoginWithCustomID(rewuest, OnLoginSuccess, OnLoginFailure);
        }

        private void Update() {

            if (Input.GetKeyDown(KeyCode.Return)) {
                GetUserData();
            }
        }


        private void OnLoginSuccess(LoginResult result) {
            Debug.Log("Congratulations, you made your first successful API call!");
        }

        private void OnLoginFailure(PlayFabError error) {
            Debug.LogWarning("Something went wrong with your first API call.  :(");
            Debug.LogError("Here's some debug information:");
            Debug.LogError(error.GenerateErrorReport());
        }



        void GetUserData() {
            PlayFabClientAPI.GetUserData(new GetUserDataRequest(), 
                result => { Debug.Log(result.Data["Name"].Value);}, 
                error => {Debug.Log(error.GenerateErrorReport());});
        }

    }

}
