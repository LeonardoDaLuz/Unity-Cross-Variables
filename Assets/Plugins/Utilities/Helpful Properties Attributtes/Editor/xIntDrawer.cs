using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;


[CustomPropertyDrawer(typeof(xint))]
public class xIntDrawer : PropertyDrawerGFPro
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var xint = (xint)property.GetObjectValue();

        if (xint.xBrain == null)
        {
            xint.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).GetComponent<XBrain>();
            if (xint.xBrain == null)
            {
                xint.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).gameObject.AddComponent<XBrain>();
                return;
            }
        }

        xint.xIndex = xint.xBrain.GetXIntIndex(xint.xIndex, property.name);

        if (xint.xIndex == -1)
        {
            xint.xBrain.CreateXIntData(property.name, false, property.propertyPath, (MonoBehaviour)property.serializedObject.targetObject);
            xint.xIndex = xint.xBrain.GetXIntIndex(xint.xIndex, property.name);

            if (xint.xIndex == -1)
                return;
        }

        var style = new GUIStyle(GUI.skin.label);
        style.normal.textColor += new Color(0.4f, -0.4f, -0.4f);
        EditorGUI.LabelField(position, property.displayName, style);
        xint.Set(EditorGUI.IntField(position, " ", xint));
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 16f;
    }
}
