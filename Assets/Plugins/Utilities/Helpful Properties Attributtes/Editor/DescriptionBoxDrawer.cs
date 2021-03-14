using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using UnityEditor.Animations;

[CustomPropertyDrawer(typeof(DescriptionBoxAttribute))]
public class DescriptionBoxDrawer : PropertyDrawer
{
    DescriptionBoxAttribute target { get { return ((DescriptionBoxAttribute)attribute); } }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        float OriginalHeight = position.height;
        position.height = target.height;
        EditorGUI.HelpBox(position, target.text, MessageType.None);
        position.y += position.height;
        position.height = EditorGUI.GetPropertyHeight(property); 
        if(!target.hideProperty)
            EditorGUI.PropertyField(position, property);

    }


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return (target.hideProperty ? 0f : EditorGUI.GetPropertyHeight(property, label)) + target.height;

    }
}
