using System.Threading.Tasks;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Modal;
using TMPro;

namespace Project.View {

    public class TestModal : Modal {

        [SerializeField] TextMeshProUGUI _textInit;
        [SerializeField] TextMeshProUGUI _textPush;

        public int No_init { get; set; } = 0;
        public int No_willPush { get; set; } = 0;


        public override Task Initialize() {
            Debug.Log("[Modal] Initialize");


            _textInit.text = $"Init : {No_init}";
            return Task.CompletedTask;
        }

        public override Task WillPushEnter() {
            Debug.Log("[Modal] Will Push Enter");

            _textPush.text = $"Will Push : {No_willPush}";
            return Task.CompletedTask;
        }
        
        public override Task WillPushExit() {
            Debug.Log("[Modal] Will Push Exit");

            return Task.CompletedTask;
        }
    }
}
