using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExamplePupupContent : PopupWindowContent
{
    public override void OnGUI(Rect rect)
    {
        EditorGUILayout.LabelField("Label");
    }

    public override void OnOpen()
    {
        Debug.Log("表示Popup窗口已呼出");
    }

    public override void OnClose()
    {
        Debug.Log("表示Popup窗口已关闭");
    }

    public override Vector2 GetWindowSize()
    {
        return new Vector2(300, 200);
    }
}