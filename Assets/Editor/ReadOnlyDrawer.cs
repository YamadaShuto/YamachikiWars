using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Inspector display setting
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
// PropertyDrawer -> 
public class ReadOnlyDrawer : PropertyDrawer
{
    // Update display processing
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // not edit for Inspector
        GUI.enabled = false;
        // Draws the proparty in the specified area
        EditorGUI.PropertyField(position, property, label, true);
        // Can edit for Inspector
        GUI.enabled = true;
    }
}
