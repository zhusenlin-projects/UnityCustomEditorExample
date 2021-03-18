using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EditorWindowExample : EditorWindow
{
    private bool toogle;

    private int intNum;
    private bool toogle2;
    [MenuItem("CustomEditor/Windows/Example")]
    private static void Open()
    {
        GetWindow<EditorWindowExample>();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("示例1：BeginChangeCheck()和EndChangeCheck()的使用");

        EditorGUI.BeginChangeCheck();
        toogle = EditorGUILayout.ToggleLeft("Toggle：改变则会在控制台上Debug出语句", toogle);
        if (EditorGUI.EndChangeCheck())
            Debug.Log("Toggle状态发生了改变");

        EditorGUILayout.Space(20);

        EditorGUILayout.LabelField("示例2：BeginDisabledGroup()和EndDisabledGroup()的使用");
        Display();
        EditorGUILayout.Space();
        EditorGUI.BeginDisabledGroup(true);
        Display();
        EditorGUI.EndDisabledGroup();
    }

    private void Display()
    {
        toogle2=EditorGUILayout.ToggleLeft("Toggle2", toogle2);
        intNum = EditorGUILayout.IntSlider(intNum, 0, 10);
        GUILayout.Button("Button");
    }
}
