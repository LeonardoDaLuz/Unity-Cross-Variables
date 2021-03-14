using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomPropertyDrawer(typeof(XPrimitivesRequireds))]
public class XBoolRequiredsDrawer : PropertyDrawerGFPro
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (Application.isPlaying)
            return;
        var XPrimitiveRequires = (XPrimitivesRequireds)property.GetObjectValue();
        if (XPrimitiveRequires == null)
            return;

        if (XPrimitiveRequires.xBrain == null)
        {
            XPrimitiveRequires.requireds = new XPrimitivesRequireds.XPrimitiveRequired[0];
            XPrimitiveRequires.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).GetComponent<XBrain>();
            if (XPrimitiveRequires.xBrain == null)
            {
                XPrimitiveRequires.xBrain = ((MonoBehaviour)property.serializedObject.targetObject).gameObject.AddComponent<XBrain>();
                return;
            }


        }
        position.height = 16f;
        property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, property.displayName);

        if (property.isExpanded)
        {
            float defaultWidth = position.width;
            float defaultX = position.x;

            object[] listPackage = XPrimitiveRequires.xBrain.getXPrimitivesList();
            string[] nameList = (string[])listPackage[0];
            XPrimitivesRequireds.XPrimitiveRequired.valueType[] typeList = (XPrimitivesRequireds.XPrimitiveRequired.valueType[])listPackage[1];
            int[] xIndexList = (int[])listPackage[2];

            if (XPrimitiveRequires.requireds == null)
            {
                    XPrimitiveRequires.requireds = new XPrimitivesRequireds.XPrimitiveRequired[0];
                Debug.Log("xboolRequires.requireds = new XBoolRequireds.XboolRequired[0];");
            }

            for (int i = 0; i < XPrimitiveRequires.requireds.Length; i++)
            {
                int index = ArrayUtility.IndexOf(nameList, XPrimitiveRequires.requireds[i].varName);

                if (index < 0 || index > nameList.Length - 1)
                {
                    ArrayUtility.RemoveAt(ref XPrimitiveRequires.requireds, i);
                    i--;
                    continue;
                }

                switch (typeList[index])
                {
                    case XPrimitivesRequireds.XPrimitiveRequired.valueType._bool:
                        position.width = defaultWidth - 16f;
                        position.x = defaultX;
                        position.y += 16f;
                        index = EditorGUI.Popup(position, index, nameList);
                        XPrimitiveRequires.requireds[i].varName = nameList[index];
                        XPrimitiveRequires.requireds[i].xIndex = xIndexList[index];
                        XPrimitiveRequires.requireds[i].ValueType = XPrimitivesRequireds.XPrimitiveRequired.valueType._bool;
                        position.x += position.width;
                        position.width = 16f;

                        XPrimitiveRequires.requireds[i].requiredBoolValue = EditorGUI.Toggle(position, XPrimitiveRequires.requireds[i].requiredBoolValue);
                        if (i < XPrimitiveRequires.requireds.Length - 1)
                        {
                            position.x = defaultX + defaultWidth * 0.5f - 21f;
                            position.y += 16f;
                            position.width = 42f;
                            int operationIndex = EditorGUI.Popup(position, XPrimitiveRequires.requireds[i].operation == XPrimitivesRequireds.XPrimitiveRequired._Operation.And ? 0 : 1, new string[] { "And", "Or" });
                            XPrimitiveRequires.requireds[i].operation = operationIndex == 0 ? XPrimitivesRequireds.XPrimitiveRequired._Operation.And : XPrimitivesRequireds.XPrimitiveRequired._Operation.Or;
                        }
                        break;
                    case XPrimitivesRequireds.XPrimitiveRequired.valueType._int:
                        position.width = defaultWidth - 96f;
                        position.x = defaultX;
                        position.y += 16f;
                        index = EditorGUI.Popup(position, index, nameList);
                        XPrimitiveRequires.requireds[i].varName = nameList[index];
                        XPrimitiveRequires.requireds[i].xIndex = xIndexList[index];
                        XPrimitiveRequires.requireds[i].ValueType = XPrimitivesRequireds.XPrimitiveRequired.valueType._int;
                        position.x += position.width;
                        position.width = 60f;
                        int comparisonTypeIndex = EditorGUI.Popup(position, 
                            XPrimitiveRequires.requireds[i].NumberComparisonType==XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.equal?0:
                            XPrimitiveRequires.requireds[i].NumberComparisonType == XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.lower ? 1 : 2
                            , new string[] { "Equal", "Lower", "Greater" });

                        XPrimitiveRequires.requireds[i].NumberComparisonType = 
                            comparisonTypeIndex == 0 ? XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.equal : 
                            comparisonTypeIndex == 1 ? XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.lower :
                            XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.greater;

                        position.x += position.width;
                        position.width = 32f;
                        XPrimitiveRequires.requireds[i].requiredintValue = EditorGUI.IntField(position, XPrimitiveRequires.requireds[i].requiredintValue);
                        if (i < XPrimitiveRequires.requireds.Length - 1)
                        {
                            position.x = defaultX+defaultWidth*0.5f-21f;
                            position.y += 16f;
                            position.width = 42f;
                            int operationIndex = EditorGUI.Popup(position, XPrimitiveRequires.requireds[i].operation == XPrimitivesRequireds.XPrimitiveRequired._Operation.And ? 0 : 1, new string[] { "And", "Or" });
                            XPrimitiveRequires.requireds[i].operation = operationIndex == 0 ? XPrimitivesRequireds.XPrimitiveRequired._Operation.And : XPrimitivesRequireds.XPrimitiveRequired._Operation.Or;
                        }
                        break;
                    case XPrimitivesRequireds.XPrimitiveRequired.valueType._float:
                        position.width = defaultWidth - 96f;
                        position.x = defaultX;
                        position.y += 16f;
                        index = EditorGUI.Popup(position, index, nameList);
                        XPrimitiveRequires.requireds[i].varName = nameList[index];
                        XPrimitiveRequires.requireds[i].xIndex = xIndexList[index];
                        XPrimitiveRequires.requireds[i].ValueType = XPrimitivesRequireds.XPrimitiveRequired.valueType._float;
                        position.x += position.width;
                        position.width = 60f;
                        int comparisonTypeIndex2 = EditorGUI.Popup(position,
                            XPrimitiveRequires.requireds[i].NumberComparisonType == XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.equal ? 0 :
                            XPrimitiveRequires.requireds[i].NumberComparisonType == XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.lower ? 1 : 2
                            , new string[] { "Equal", "Lower", "Greater" });

                        XPrimitiveRequires.requireds[i].NumberComparisonType =
                            comparisonTypeIndex2 == 0 ? XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.equal :
                            comparisonTypeIndex2 == 1 ? XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.lower :
                            XPrimitivesRequireds.XPrimitiveRequired.numberComparisonType.greater;

                        position.x += position.width;
                        position.width = 32f;
                        XPrimitiveRequires.requireds[i].requiredfloatValue = EditorGUI.FloatField(position, XPrimitiveRequires.requireds[i].requiredfloatValue);
                        if (i < XPrimitiveRequires.requireds.Length - 1)
                        {
                            position.x = defaultX + defaultWidth * 0.5f - 21f;
                            position.y += 16f;
                            position.width = 42f;
                            int operationIndex = EditorGUI.Popup(position, XPrimitiveRequires.requireds[i].operation == XPrimitivesRequireds.XPrimitiveRequired._Operation.And ? 0 : 1, new string[] { "And", "Or" });
                            XPrimitiveRequires.requireds[i].operation = operationIndex == 0 ? XPrimitivesRequireds.XPrimitiveRequired._Operation.And : XPrimitivesRequireds.XPrimitiveRequired._Operation.Or;
                        }
                        break;
                    default:
                        break;
                }
            //    XPrimitiveRequires.requireds[i].requiredBoolValue = EditorGUI.Toggle(position, XPrimitiveRequires.requireds[i].requiredBoolValue);


            }
            position.y += 16f;
            position.width = 22f;
            position.x = defaultX + defaultWidth * 0.5f - 22f;

            if (XPrimitiveRequires.xBrain.xBoolList.Length < 1)
                return;

            if (GUI.Button(position, "+"))
            {
                Debug.Log(property.serializedObject.targetObject.name + " --- ");
                var newElement = new XPrimitivesRequireds.XPrimitiveRequired();
                newElement.varName = XPrimitiveRequires.xBrain.xBoolList[0].varName;
                ArrayUtility.Add(ref XPrimitiveRequires.requireds, newElement);
                UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
                property.serializedObject.Update();
            }
            position.x += position.width;
            if (XPrimitiveRequires.requireds.Length > 0 && GUI.Button(position, "-"))
            {
                ArrayUtility.RemoveAt(ref XPrimitiveRequires.requireds, XPrimitiveRequires.requireds.Length - 1);
                UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
                property.serializedObject.Update();
            }
        }

    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (Application.isPlaying)
            return-2f;

        if (property.isExpanded)
        {
            var obj = property.GetObjectValue();
            if (obj != null)
            {
                var xbool = (XPrimitivesRequireds)property.GetObjectValue();
                if (xbool.xBrain != null && xbool.requireds != null)
                    return 32f + xbool.requireds.Length * 32f;
            }
            else
            {
                return 32;
            }
        }
        return 16f;
    }
}



