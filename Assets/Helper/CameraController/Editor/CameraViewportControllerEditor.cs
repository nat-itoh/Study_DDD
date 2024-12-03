#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Project.CameraModule.EditorSctipts
{
    /// <summary>
    /// <see cref="CameraViewportController"/>のインスペクタ拡張
    /// </summary>
    [CustomEditor(typeof(CameraViewportController))]
    public class CameraViewportControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var instance = target as CameraViewportController;

            // コンポーネント説明文
            var message = "カメラのViewport値を制御するコンポーネント.\n" 
                + "指定したUI要素のRectにViewportをフィットさせます.";
            EditorGUILayout.HelpBox(message, MessageType.Info);


            EditorGUILayout.LabelField("Settings", EditorStyles.boldLabel);
            using (new EditorGUI.IndentLevelScope())
            {
                var rectTrans = EditorGUILayout.ObjectField("Target Rect", instance.TargetRect, typeof(RectTransform), true) as RectTransform;
                instance.SetTarget(rectTrans);
                instance.applay = EditorGUILayout.Toggle("Apply", instance.applay);
                if (instance.applay)
                {
                    // ※smoothTimeは正の値に制限する
                    var newValue = EditorGUILayout.FloatField("smoothTime", instance.smoothTime);
                    instance.smoothTime = Mathf.Max(0f, newValue);
                }
            }
        }
    }
}
#endif