using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UseHideFlags : MonoBehaviour
{
    [MenuItem("CustomEditor/HideFlags/Set to HideFlags.None")]
    public static void SetToHideFlags_None()
    {
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        Debug.Log(path);
        foreach(var item in AssetDatabase.LoadAllAssetsAtPath(path))
        {
            item.hideFlags = HideFlags.None;
        }
        AssetDatabase.ImportAsset(path);
    }

    [MenuItem("CustomEditor/HideFlags/Set to HideFlags.HideInHierarchy")]
    public static void SetToHideFlags_HideInHierarchy()
    {
        var path = AssetDatabase.GetAssetPath(Selection.activeObject);
        Debug.Log(path);
        foreach (var item in AssetDatabase.LoadAllAssetsAtPath(path))
        {
            item.hideFlags = HideFlags.HideInHierarchy;
        }
        AssetDatabase.ImportAsset(path);
        AssetDatabase.Refresh();
    }
}
