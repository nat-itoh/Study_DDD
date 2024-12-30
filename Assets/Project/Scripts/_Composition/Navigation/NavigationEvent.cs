using UniRx;
using UnityEngine;

namespace Project.Composition {

    // Presentaion Layer
    public enum NavigationEvent {

        TopPage_Tap,
        HomePage_SettingsButtonClicked,
        HomePage_CreditButtonClicked,
    }
    public class NavigationEventStream {
        public readonly Subject<NavigationEvent> OnNavigate = new ();
    }


    // Composition Layer
    public class NavigationHandler {
        public NavigationHandler(NavigationEventStream navigationEventStream) {
            navigationEventStream.OnNavigate.Subscribe(navigationEvent => {
                
                switch (navigationEvent) {
                    case NavigationEvent.TopPage_Tap:
                        break;
                    case NavigationEvent.HomePage_SettingsButtonClicked:
                        break;
                    case NavigationEvent.HomePage_CreditButtonClicked:
                        break;
                }
            });
        }
    }
}
