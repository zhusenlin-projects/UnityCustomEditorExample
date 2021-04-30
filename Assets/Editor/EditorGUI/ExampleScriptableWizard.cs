using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExampleScriptableWizard : ScriptableWizard
{
    public string gameObjectName;

    [MenuItem("CustomEditor/Windows/ExampleScriptableWizard")]
    private static void Open()
    {
        DisplayWizard<ExampleScriptableWizard>("Example Wizard","CREATE","FIND");
        
    }

    /// <summary>
    /// 创建按钮的事件
    /// </summary>
    private void OnWizardCreate()
    {
        new GameObject(gameObjectName);
    }

    /// <summary>
    /// 其他按钮的事件
    /// </summary>
    private void OnWizardOtherButton()
    {
        var gameObject = GameObject.Find(gameObjectName);
        if (gameObject == null)
            Debug.Log("未找到相关的游戏对象");
    }

    /// <summary>
    /// 当所有字段值的值发生更改时要调用的方法
    /// </summary>
    private void OnWizardUpdate()
    {
        Debug.Log("字段发生更改");
    }

    protected override bool DrawWizardGUI()
    {
        EditorGUILayout.LabelField("CUSTOM GUI");
        return true;
    }
}