using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomPropertyDrawer(typeof(xbool))]
public class xboolDrawer : PropertyDrawerGFPro
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
            var xbool = (xbool)property.GetObjectValue();

            if (xbool.xBrain == null)
            {
                xbool.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).GetComponent<XBrain>();
                if (xbool.xBrain == null)
                {
                    xbool.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).gameObject.AddComponent<XBrain>();
                    return;
                }
            }


            xbool.xIndex = xbool.xBrain.GetXBoolIndex(xbool.xIndex, property.name);

            if (xbool.xIndex == -1)
            {
                xbool.xBrain.CreateXBoolData(property.name, false, property.propertyPath, (MonoBehaviour)property.serializedObject.targetObject);
                xbool.xIndex = xbool.xBrain.GetXBoolIndex(xbool.xIndex, property.name);

                if (xbool.xIndex == -1)
                    return;
            }

        var style = new GUIStyle(GUI.skin.label);
        style.normal.textColor += new Color(-0.4f,0.4f,-0.4f);
        EditorGUI.LabelField(position, property.displayName, style);
        xbool.Set(EditorGUI.Toggle(position," ", xbool));

    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 16f;
    }
}




