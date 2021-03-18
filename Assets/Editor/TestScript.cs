using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        SerializedObject so = new SerializedObject(Camera.main);
        Debug.Log("通过SerializedObject查找到Main Camera实例的depth值为：" + so.FindProperty("depth").floatValue);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
