using UnityEngine;

namespace Project.CameraModule {

    /// <summary>
    /// <see cref="CameraLocationController"/>�̔�ʑ̂ƂȂ�I�u�W�F�N�g
    /// </summary>
    [SelectionBase]
    [DisallowMultipleComponent]
    public class CameraTarget : MonoBehaviour, ICameraTarget {
        
        /// <summary>
        /// ���S���W
        /// </summary>
        public Vector3 Position {
            get => transform.position;
            set => transform.position = value;
        }


    }

}