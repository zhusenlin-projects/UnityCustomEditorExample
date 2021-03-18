using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Reflection;

public class EditorLoadResource
{
    //[InitializeOnLoadMethod]
    private static void TestSomeAPI()
    {
        LoadResourceExample();
        GetBuildInAssetName();
    }


    /// <summary>
    /// 加载资源的例子
    /// </summary>
    private static void LoadResourceExample()
    {
        //加载资源文件夹示例
        var tex = EditorGUIUtility.Load("Game.png") as Texture;
        if (tex != null)
            Debug.Log($"Texture Name:{tex.name} Texture Size:{tex.width}*{tex.height}");
        else
            Debug.Log("Load Resource Error!");
    }

    /// <summary>
    /// 获取内置资源包资源列表
    /// Tips:在此版本中获取失败，原因未知
    /// </summary>
    private static void GetBuildInAssetName()
    {
        var flags = BindingFlags.Static | BindingFlags.NonPublic;
        var info = typeof(EditorUtility).GetMethod("GetEditorAssetBundle", flags);
        if (info != null)
        {
            var bundle = info.Invoke(null, new object[0]) as AssetBundle;
            string res = "";
            foreach (var n in bundle.GetAllAssetNames())
                res += n.ToString() + "\n";

            Debug.Log($"获取编辑器内置资源列表：\n{res}");
        }
        else
        {
            Debug.Log($"内置资源列表读取失败");
        }




    }
}
