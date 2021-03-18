using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ParentScriptableObject : ScriptableObject
{
    public const string DefaultPath = "Assets/Editor Default Resources/ScriptableObjectRes/SOCollection.asset";

    [SerializeField] ChildScriptableObject ChildSO;

    [MenuItem("CustomEditor/ScriptableObject/Create <SOCollection> asset And Save In Default Folder(Inclue <ParentScriptableObject> And <ChildScriptableObject>)")]
    private static void CreateScriptableObject()
    {
        var parent = ScriptableObject.CreateInstance<ParentScriptableObject>();

        parent.ChildSO = ScriptableObject.CreateInstance<ChildScriptableObject>();

        AssetDatabase.AddObjectToAsset(parent.ChildSO, DefaultPath);
        AssetDatabase.CreateAsset(parent, DefaultPath);

        AssetDatabase.ImportAsset(DefaultPath);

        AssetDatabase.Refresh();
    }
}
