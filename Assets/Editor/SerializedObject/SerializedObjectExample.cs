using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SerializedObjectExample : MonoBehaviour
{
    [InitializeOnLoadMethod]
    private static void TextSomeAPI()
    {
        CheckPropertyPaths();
    }

    private static void CheckPropertyPaths()
    {
        var so = new SerializedObject(Texture2D.whiteTexture);
        var pop = so.GetIterator();
        string s = "【Texture2D.whiteTexture】的数据读取如下\n";
        while (pop.NextVisible(true))
            s+=pop.propertyPath+"\n";

        Debug.Log(s);
    }

    /// <summary>
    /// 运行时可调用
    /// </summary>
    public static void GetValueBySerializedObject()
    {
        SerializedObject so = new SerializedObject(Camera.main);
        Debug.Log("通过SerializedObject查找到Main Camera实例的depth值为：" + so.FindProperty("depth").floatValue);
    }
}
