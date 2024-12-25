using Cysharp.Threading.Tasks;
using Demo.Subsystem.PresentationFramework;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Project.View.Utils;

namespace Project.View.Setting {

    public class GraphicsSettingsView : AppView<GraphicsSettingsViewState>{

        [SerializeField] TMP_Dropdown _resolutionDropdown;


        /// <summary>
        /// ‰Šú‰»ˆ—D
        /// </summary>
        protected override UniTask Initialize(GraphicsSettingsViewState state) {

            return UniTask.CompletedTask;
        }
    }
}
