using System;
using UniRx;
using UnityEngine.UI;

namespace Project.View.Utils {

    public static class SliderExtensions {

        public static IDisposable SetOnValueChangedDestination(this Slider self, Action<float> onValueChanged)
        {
            return self.onValueChanged
                .AsObservable()
                .Subscribe(onValueChanged.Invoke)
                .AddTo(self);
        }
    }
}
