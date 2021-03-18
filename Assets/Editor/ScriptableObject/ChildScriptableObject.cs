using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChildScriptableObject : ScriptableObject
{

    public static string DefaultPath = "Assets/Editor Default Resources/ScriptableObjectRes/ChildSO.asset";

    public string tip = "这是一个存于ChildScriptableObject的数据";

    /// <summary>
    /// 创建ScriptableObject文件
    /// </summary>
    [MenuItem("CustomEditor/ScriptableObject/Create <ChildScriptableObject> asset And Save In Default Folder")]
    private static void CreateExampleAsset()
    {
        var exampleAsset = CreateInstance<ChildScriptableObject>();
        AssetDatabase.CreateAsset(exampleAsset, DefaultPath);
        AssetDatabase.Refresh();
    }
}
