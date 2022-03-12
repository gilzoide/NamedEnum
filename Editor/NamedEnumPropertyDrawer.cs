using UnityEditor;
using UnityEngine;

namespace Gilzoide.NamedEnum.Editor
{
    [CustomPropertyDrawer(typeof(NamedEnum<>))]
    public class NamedEnumPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProperty = property.FindPropertyRelative("_value");
            
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, valueProperty, label);
            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }

            SerializedProperty nameProperty = property.FindPropertyRelative("_name");
            nameProperty.stringValue = valueProperty.enumNames[valueProperty.enumValueIndex];
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property.FindPropertyRelative("_value"), label);
        }
    }
}