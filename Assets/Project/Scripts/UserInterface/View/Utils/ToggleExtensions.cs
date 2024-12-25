using System;
using UniRx;
using UnityEngine.UI;

namespace Project.View.Utils {

    public static class ToggleExtensions {

        public static IDisposable SetOnValueChangedDestination(this Toggle self, Action<bool> onValueChanged) {
            return self.onValueChanged
                .AsObservable()
                .Subscribe(onValueChanged.Invoke)
                .AddTo(self);
        }
    }
}
