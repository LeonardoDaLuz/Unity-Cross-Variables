using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomPropertyDrawer(typeof(sincronizeWithAnimator))]
public class sincronizeWithAnimatorDrawer : PropertyDrawerGFPro
{
    sincronizeWithAnimator target
    {
        get { return (sincronizeWithAnimator)attribute; }
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var obj = property.GetObjectValue();
        if (obj.GetType() == typeof(xbool))
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

            if (!Application.isPlaying)
            {
                xbool.xIndex = xbool.xBrain.GetXBoolIndex(xbool.xIndex, property.name);

                if (xbool.xIndex == -1)
                {
                    xbool.xBrain.CreateXBoolData(property.name, true, property.propertyPath, (MonoBehaviour)property.serializedObject.targetObject);
                    xbool.xIndex = xbool.xBrain.GetXBoolIndex(xbool.xIndex, property.name);

                    if (xbool.xIndex == -1)
                        return;
                }

                xbool.xBrain.ResolveAnimatorBoolParameter(xbool.xIndex, true);
            }

            if (!target.hide)
            {
                var style = new GUIStyle(GUI.skin.label);
                style.normal.textColor += new Color(-0.4f, 0.4f, -0.4f);
                EditorGUI.LabelField(position, property.displayName, style);
                xbool.Set(EditorGUI.Toggle(position, " ", xbool, GUI.skin.toggle));
            }
        }
        else if (obj.GetType() == typeof(xfloat))
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

            if (!Application.isPlaying)
            {
                xfloat.xIndex = xfloat.xBrain.GetXFloatIndex(xfloat.xIndex, property.name);

                if (xfloat.xIndex == -1)
                {
                    xfloat.xBrain.CreateXFloatData(property.name, true, property.propertyPath, (MonoBehaviour)property.serializedObject.targetObject);
                    xfloat.xIndex = xfloat.xBrain.GetXFloatIndex(xfloat.xIndex, property.name);

                    if (xfloat.xIndex == -1)
                        return;
                }

                xfloat.xBrain.ResolveAnimatorFloatParameter(xfloat.xIndex, true);
            }

            if (!target.hide)
            {
                var style = new GUIStyle(GUI.skin.label);
                style.normal.textColor += new Color(-0.4f, 0.4f, -0.4f);
                EditorGUI.LabelField(position, property.displayName, style);
                xfloat.Set(EditorGUI.FloatField(position, " ", xfloat));
            }
        }
        else if (obj.GetType() == typeof(xint))
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

            if (!Application.isPlaying)
            {
                xint.xIndex = xint.xBrain.GetXIntIndex(xint.xIndex, property.name);

                if (xint.xIndex == -1)
                {
                    xint.xBrain.CreateXIntData(property.name, true, property.propertyPath, (MonoBehaviour)property.serializedObject.targetObject);
                    xint.xIndex = xint.xBrain.GetXIntIndex(xint.xIndex, property.name);

                    if (xint.xIndex == -1)
                        return;
                }

                xint.xBrain.ResolveAnimatorIntParameter(xint.xIndex, true);
            }

            if (!target.hide)
            {
                var style = new GUIStyle(GUI.skin.label);
                style.normal.textColor += new Color(-0.4f, 0.4f, -0.4f);
                EditorGUI.LabelField(position, property.displayName, style);
                xint.Set(EditorGUI.IntField(position, " ", xint));
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (!target.hide)
            return 16f;
        else
            return -2f;
    }
}