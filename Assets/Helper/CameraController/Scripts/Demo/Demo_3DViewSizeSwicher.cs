using UnityEngine;
using UnityEngine.UI;

using Project.CameraModule;

public class Demo_3DViewSizeSwicher: MonoBehaviour
{

    [SerializeField] CameraViewportController _cameraViewportController;
    [SerializeField] RectTransform _rect;

    private void OnEnable()
    {
        _cameraViewportController.SetTarget(_rect);
    }

    private void OnDisable()
    {
        _cameraViewportController.SetTarget(null);
    }

}
