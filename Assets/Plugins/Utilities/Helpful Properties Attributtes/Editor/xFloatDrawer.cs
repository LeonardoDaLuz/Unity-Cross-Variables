using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;


[CustomPropertyDrawer(typeof(xfloat))]
public class xfloatDrawer : PropertyDrawerGFPro
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var xfloat = (xfloat)property.GetObjectValue();

        if (xfloat.xBrain == null)
        {
            xfloat.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).GetComponent<XBrain>();
            if (xfloat.xBrain == null)
            {
                xfloat.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).gameObject.AddComponent<XBrain>();
                return;
            }
        }

        xfloat.xIndex = xfloat.xBrain.GetXFloatIndex(xfloat.xIndex, property.name);

        if (xfloat.xIndex == -1)
        {
            xfloat.xBrain.CreateXFloatData(property.name, false, property.propertyPath, (MonoBehaviour)property.serializedObject.targetObject);
            xfloat.xIndex = xfloat.xBrain.GetXFloatIndex(xfloat.xIndex, property.name);

            if (xfloat.xIndex == -1)
                return;
        }

        var style = new GUIStyle(GUI.skin.label);
        style.normal.textColor += new Color(-0.4f, 0.4f, -0.4f);
        EditorGUI.LabelField(position, property.displayName, style);
        xfloat.Set(EditorGUI.FloatField(position, " ", xfloat));
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 16f;
    }
}
