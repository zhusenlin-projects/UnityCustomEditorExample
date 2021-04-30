using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorWindowExample2 : EditorWindow
{
    private static EditorWindowExample2 exWindow;
    private static ExamplePupupContent pupupContent = new ExamplePupupContent();

    [MenuItem("CustomEditor/Windows/Example2")]
    private static void Open()
    {
        if (exWindow == null)
            exWindow = CreateInstance<EditorWindowExample2>();


        exWindow.Show();               //常规的显示方式

        //exWindow.ShowUtility();        //始终显示在前台（即使焦点在其他Windows）

        //exWindow.ShowPopup();          //没有标题，也没有关闭按钮。所以必须自己实现关闭窗口的过程

        /*
        var buttonRect = new Rect(100, 100, 300, 100);
        var windowSize = new Vector2(300, 100);
        exWindow.ShowAsDropDown(buttonRect,windowSize);
        */
    }

    private void OnGUI()
    {
        //按下Escape键关闭窗口
        if (Event.current.keyCode == KeyCode.Escape)
        {
            exWindow.Close();
        }

        if (GUILayout.Button("PopupContent", GUILayout.Width(128)))
        {
            var activatorRect = GUILayoutUtility.GetLastRect();
            PopupWindow.Show(activatorRect, pupupContent);
        }
    }
}