using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 同版本的EditorPrefs的数值通用
/// 本脚本存入了自动保存时间间隔（float）
/// 窗口的大小（width、height）
/// </summary>
public class UseEditorPres : EditorWindow
{
    private int intervalTime = 60;

    private const string AUTO_SAVE_INTERVAL_TIME = "Auto Save Interval Time (sec)";
    private const string SIZE_WINDOW_WIDTH= "EditorPrefsExampleWindow size width";
    private const string SIZE_WINDOW_HEIGHT = "EditorPrefsExampleWindow size height";

    [MenuItem("CustomEditor/Windows/EditorPrefsExampleWindow")]
    private static void Open()
    {
        GetWindow<UseEditorPres>();
    }

    private void OnEnable()
    {
        var width = EditorPrefs.GetFloat(SIZE_WINDOW_WIDTH, 600);
        var height = EditorPrefs.GetFloat(SIZE_WINDOW_HEIGHT, 400);
        position = new Rect(position.x, position.y, width, height);

        intervalTime = EditorPrefs.GetInt(AUTO_SAVE_INTERVAL_TIME, 60);
    }

    private void OnDisable()
    {
        EditorPrefs.SetFloat(SIZE_WINDOW_WIDTH, position.width);
        EditorPrefs.SetFloat(SIZE_WINDOW_HEIGHT, position.height);
    }

    private void OnGUI()
    {
        EditorGUI.BeginChangeCheck();
        intervalTime = EditorGUILayout.IntSlider("间隔（秒）", intervalTime, 1, 3600);

        //当数值被修改时
        if(EditorGUI.EndChangeCheck())
        {
            EditorPrefs.SetInt(AUTO_SAVE_INTERVAL_TIME, intervalTime);
        }
    }


    /// <summary>
    /// 类似EditorPrefs,用于编辑器数据持久化
    /// 但与EditorPrefs不同的是，它是二进制格式存储，并进行了加密（不能像EditorPrefs一样在注册表中查看值）
    /// </summary>
    //[InitializeOnLoadMethod]
    public static void SaveConfig()
    {
        EditorUserSettings.SetConfigValue("Data 1", "Secret STR");

        Debug.Log($"Data 1:{EditorUserSettings.GetConfigValue("Data 1")}");
    }
}
