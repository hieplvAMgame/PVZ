
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class CustomEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = (ShowIfAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIf.ConditionField);

        if (conditionProperty != null && conditionProperty.boolValue == showIf.ExpectedValue)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        ShowIfAttribute showIf = (ShowIfAttribute)attribute;
        SerializedProperty conditionProperty = property.serializedObject.FindProperty(showIf.ConditionField);

        if (conditionProperty != null && conditionProperty.boolValue == showIf.ExpectedValue)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        return 0; 
    }
}
public class ShowIfAttribute : PropertyAttribute
{
    public string ConditionField { get; }
    public bool ExpectedValue { get; }

    public ShowIfAttribute(string conditionField, bool expectedValue = true)
    {
        ConditionField = conditionField;
        ExpectedValue = expectedValue;
    }
}