using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(CS_Range))]
public class ExamplePropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            var minNumProperty = property.FindPropertyRelative("minNum");
            var maxNumProperty = property.FindPropertyRelative("maxNum");

            var minMaxSliderRect = new Rect(position) { height = position.height * 0.5f };
            var labelRect = new Rect(minMaxSliderRect)
            {
                x = minMaxSliderRect.x + EditorGUIUtility.labelWidth,
                y = minMaxSliderRect.y + minMaxSliderRect.height
            };

            float min = minNumProperty.intValue;
            float max = maxNumProperty.intValue;

            EditorGUI.BeginChangeCheck();
            EditorGUI.MinMaxSlider(label, minMaxSliderRect, ref min, ref max, 0, 100);
            EditorGUI.LabelField(labelRect, min.ToString(), max.ToString());
            if (EditorGUI.EndChangeCheck())
            {
                minNumProperty.intValue = Mathf.FloorToInt(min);
                maxNumProperty.intValue = Mathf.FloorToInt(max);
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * 2;
    }
}