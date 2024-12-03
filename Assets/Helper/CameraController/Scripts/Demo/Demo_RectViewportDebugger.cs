using UnityEngine;
using Project.Utils;

public class Demo_RectViewportDebugger : MonoBehaviour{

    [Header("Viewport値の可視化用コンポーネント")]
    public RectTransform rectTrans;
    public Rect viewport;

    void Update()
    {
        if (rectTrans == null)
            return;

        viewport = rectTrans.GetViewportRect();
    }
}
