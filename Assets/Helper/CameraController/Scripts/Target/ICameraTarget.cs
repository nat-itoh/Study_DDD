using UnityEngine;

namespace Project.CameraModule {

    /// <summary>
    /// �J�����̔�ʑ�
    /// </summary>
    public interface ICameraTarget {

        Vector3 Position { get; }
    }

    /// <summary>
    /// �J�����̔�ʑ�
    /// </summary>
    public interface ICameraTargetBounds {

        /// <summary>
        /// 
        /// </summary>
        Bounds Bound { get; }
    }
}