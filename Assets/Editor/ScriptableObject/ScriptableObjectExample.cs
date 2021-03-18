using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectExample : ScriptableObject
{
    [TextArea(3, 5)] public string Intro = "这是一个ScriptableObject的示例";

    [Range(1, 10)] public int IntNum = 5;

    /// <summary>
    /// 不能直接拖拽asset文件，而是要读取到实例并赋值
    /// </summary>
    [SerializeField]
    public ChildScriptableObject childSO;  

    public const string DefaultPath = "Assets/Editor Default Resources/ScriptableObjectRes/SObjExample.asset";

    /// <summary>
    /// 创建ScriptableObject实例
    /// 注意：文件夹要提前创建好
    /// </summary>
    [MenuItem("CustomEditor/ScriptableObject/Create <ScriptableObjectExample> Instance")]
    private static void CreateExampleAssetInstance()
    {
        var exampleAsset = CreateInstance<ScriptableObjectExample>();
        if (exampleAsset != null)
            Debug.Log($"生成ScriptableObject实例{exampleAsset.name}");
        else
            Debug.Log("创建的ScriptableObject实例为空[typeof(ScriptableObjectExample)]");
    }

    /// <summary>
    /// 创建ScriptableObject文件
    /// </summary>
    [MenuItem("CustomEditor/ScriptableObject/Create <ScriptableObjectExample> asset And Save In Default Folder")]
    private static void CreateExampleAsset()
    {
        var exampleAsset = CreateInstance<ScriptableObjectExample>();
        AssetDatabase.CreateAsset(exampleAsset, DefaultPath);

        var childAsset = ScriptableObject.CreateInstance<ChildScriptableObject>();
        exampleAsset.childSO = childAsset;
        AssetDatabase.Refresh();
    }

    [MenuItem("CustomEditor/ScriptableObject/Read [SObjExample.asset] Data")]
    private static void LoadScriptableObjectAsset(string path= DefaultPath)
    {
        var assetExample = AssetDatabase.LoadAssetAtPath<ScriptableObjectExample>(path);
        Debug.ClearDeveloperConsole();
        Debug.Log($"实例读取成功\nassetExample.IntNum={assetExample.IntNum}");
    }
}


