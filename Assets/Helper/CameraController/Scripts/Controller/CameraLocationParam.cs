using UnityEngine;

namespace Project.CameraModule
{
    using Project.Utils;

    [System.Serializable]
    public class CameraLocationParam
    {
        public Vector3 targetPos;
        public float tiltAngle;
        public float headingAngle;
        public float distance;
        public Vector2 offset;


        /// ----------------------------------------------------------------------------
        // Public Method

        public CameraLocationParam(Vector3 targetPos, float tiltAngle, float headingAngle, float distance, Vector2 offset)
        {
            this.targetPos = targetPos;
            this.tiltAngle = tiltAngle;
            this.headingAngle = headingAngle;
            this.distance = distance;
            this.offset = offset;

            Validate();
        }

        public CameraLocationParam(Vector3 targetPos, float tiltAngle, float headingAngle, float distance)
        {
            this.targetPos = targetPos;
            this.tiltAngle = tiltAngle;
            this.headingAngle = headingAngle;
            this.distance = distance;
            this.offset = Vector2.zero;

            Validate();
        }

        public CameraLocationParam(Vector3 targetPos, Quaternion rotation, float distance)
        {
            this.targetPos = targetPos;
            this.distance = distance;

            // Quaternionからオイラー角に変換し、tiltAngleとheadingAngleに代入
            Vector3 euler = rotation.eulerAngles;
            this.tiltAngle = AngleUtils.NormalizeAngle(euler.x);
            this.headingAngle = AngleUtils.NormalizeAngle(euler.y);
            this.offset = Vector2.zero;

            Validate();
        }

        /// <summary>
        /// パラメータのバリデーションを行い、範囲外の値を修正する
        /// </summary>
        public void Validate()
        {
            // カメラの仰角を制限する
            tiltAngle = CameraLocationController.ENABLED_LIMIT_TILT ?
                Mathf.Clamp(tiltAngle, CameraLocationController.MIN_TILT, CameraLocationController.MAX_TILT) :   //　(Min ~ X ~ Max)
                AngleUtils.NormalizeAngle(tiltAngle);  //　(-180 ~ X ~ 180)
            
            // カメラと対象の距離を制限する
            if (CameraLocationController.ENABLED_LIMIT_DISTANCE)
                distance = Mathf.Clamp(distance, CameraLocationController.MIN_DISTANCE, CameraLocationController.MAX_DISTANCE);

        }

        /// <summary>
        /// CameraLocationParam の状態を文字列として返す
        /// </summary>
        public override string ToString()
        {
            return $"Target Position: {targetPos}, Tilt Angle: {tiltAngle}, Heading Angle: {headingAngle}, Distance: {distance}, Offset: {offset}";
        }


        /// ----------------------------------------------------------------------------
        // Static Method

        public static CameraLocationParam FromAxisX(bool isPositive = true)
        {
            Vector3 direction = isPositive ? Vector3.right : Vector3.left;
            Quaternion rotation = Quaternion.LookRotation(direction);
            return new CameraLocationParam(Vector3.zero, rotation, CameraLocationController.DEFAULT_DISTANCE); // 仮のターゲット位置と距離を設定
        }

        public static CameraLocationParam FromAxisY(bool isPositive = true)
        {
            Vector3 direction = isPositive ? Vector3.up : Vector3.down;
            Quaternion rotation = Quaternion.LookRotation(direction);
            return new CameraLocationParam(Vector3.zero, rotation, CameraLocationController.DEFAULT_DISTANCE);
        }

        public static CameraLocationParam FromAxisZ(bool isPositive = true)
        {
            Vector3 direction = isPositive ? Vector3.forward : Vector3.back;
            Quaternion rotation = Quaternion.LookRotation(direction);
            return new CameraLocationParam(Vector3.zero, rotation, CameraLocationController.DEFAULT_DISTANCE);
        }
    }

}