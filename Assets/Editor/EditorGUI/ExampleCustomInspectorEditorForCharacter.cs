using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * 自定义拓展编辑器默认不能同时对多个对象的同一个组件进行修改
 * 若想要实现，需要添加[CanEditMultipleObjects]来修饰
 */
[CanEditMultipleObjects]
[CustomEditor(typeof(Character))]
public class ExampleCustomInspectorEditorForCharacter : Editor
{
    private Character chara = null;

    private SerializedProperty hpProperty;
    private SerializedProperty powerProperty;
    private void OnEnable()
    {
        chara = (Character)target;

        /*
         *   通过Unity Serializer访问类的属性
         */
        hpProperty = serializedObject.FindProperty("hp");
        powerProperty = serializedObject.FindProperty("PowerNum");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //通过属性值自定义GUI修改变量值
        serializedObject.Update();
        EditorGUILayout.IntSlider(hpProperty, 0, 100);
        EditorGUILayout.PropertyField(powerProperty);
        serializedObject.ApplyModifiedProperties();

        //通过直接获取属性的修改方式需要手动注册修改记录以便于撤回
        EditorGUI.BeginChangeCheck();
        var propsNum = EditorGUILayout.IntSlider("Prop Num", chara.propsNum, 0, 20);
        if(EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(chara, "Change Object");
            chara.propsNum = propsNum;
        }


        EditorGUILayout.LabelField("攻击力", chara.ATTACK.ToString().ToString());
    }


    public override bool HasPreviewGUI()
    {
        return true;
    }
}