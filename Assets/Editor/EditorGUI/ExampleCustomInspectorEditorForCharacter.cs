using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Character))]
public class ExampleCustomInspectorEditorForCharacter : Editor
{
    Character chara = null;

    private void OnEnable()
    {
        chara = (Character)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("攻击力", chara.ATTACK.ToString().ToString());
    }
}