using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

using Project.CameraModule;

public class Test : MonoBehaviour{

    private CameraLocationController _cameraController;
    public float duration = 0.5f;

    private async void Start()
    {
        _cameraController = GetComponent<CameraLocationController>();

    }

    private void Update()
    {
        var shift = !Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKeyDown(KeyCode.X))
        {
            var paramX = CameraLocationParam.FromAxisX(shift);
            _cameraController.SetParamsOverTime(paramX, duration);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            var paramY = CameraLocationParam.FromAxisY(shift);
            _cameraController.SetParamsOverTime(paramY, duration);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            var paramZ = CameraLocationParam.FromAxisZ(shift);
            _cameraController.SetParamsOverTime(paramZ, duration);
        }
    }
}
