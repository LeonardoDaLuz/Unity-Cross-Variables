//Cria uma dropdown com todos os states no inspector

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using UnityEditor.Animations;

[CustomPropertyDrawer(typeof(FunctionDropdownAttribute))]
public class FunctionDropdownDrawer : PropertyDrawerGFPro
{

    FunctionDropdownAttribute target { get { return ((FunctionDropdownAttribute)attribute); } }


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        target.Height = 16f;
        //Get Animator
        if (property.propertyType != SerializedPropertyType.String)
        {
            Debug.LogWarning(property.name + " isn't string type");
            return;
        }

        string initialValue = property.stringValue;
        object parentObject = property.GetParent(); //obtem o objeto que abrage esta propriedade

        if (parentObject == null)
        {
            Debug.LogError("FunctionDropdownDrawer: O parent está nulo");
            return;
        }



        FieldInfo scriptField = parentObject.GetType().GetField(target.scriptVariableName); //obtem o campo que contem o script
        if (scriptField == null)
            Debug.Log("FunctionDropdownDrawer: O scriptField está nulo");

        object scriptValue = scriptField.GetValue(parentObject); //obtem o script através do campo
        if (scriptValue == null)
        {
            scriptField.SetValue(parentObject, (MonoBehaviour)property.serializedObject.targetObject);
            scriptValue = (MonoBehaviour)property.serializedObject.targetObject;
        }
        MonoBehaviour script = (MonoBehaviour)scriptValue;
        MethodInfo[] functionsFileds = script.GetType().GetMethods(); //obtem todos os metodos do script.


        if (functionsFileds.Length < 88)
            Debug.LogError("FunctionDropdownDrawer: Incompatible unity version");

        List<string> functionNames = new List<string>();
        List<MethodInfo> functionList = new List<MethodInfo>();

        for (int i = 0; i < functionsFileds.Length - 88; i++)
        {
            ParameterInfo[] _parameters = functionsFileds[i].GetParameters();
            if (_parameters.Length == 0 || (_parameters.Length==1 && (_parameters[0].ParameterType==typeof(float) || _parameters[0].ParameterType == typeof(string) || _parameters[0].ParameterType == typeof(int) || _parameters[0].ParameterType == typeof(bool))))
            {
                functionNames.Add(functionsFileds[i].Name);
                functionList.Add(functionsFileds[i]);
            }
        }
        int index = functionNames.IndexOf(initialValue);
        position.height = 16f;
        index = EditorGUI.Popup(position, index, functionNames.ToArray());

        if (index == -1)
            return;

        property.stringValue = functionNames[index];

        ParameterInfo[] parameters = functionList[index].GetParameters();

        //Draw parameters
        position.y += 16f;
        position.height = 16f;
        if (parameters.Length == 1)
        {
            target.Height = 32f;
            if (parameters[0].ParameterType == typeof(string))
            {
                SerializedProperty sibling = GetSiblingProperty(property, "_string");
                sibling.stringValue = EditorGUI.TextField(position, sibling.stringValue);
                GetSiblingProperty(property, "parameterType").enumValueIndex=3;
            }
            else if (parameters[0].ParameterType == typeof(float))
            {
                SerializedProperty sibling = GetSiblingProperty(property, "_float");
                sibling.floatValue = EditorGUI.FloatField(position, sibling.floatValue);
                GetSiblingProperty(property, "parameterType").enumValueIndex = 1;
            }
            else if (parameters[0].ParameterType == typeof(int))
            {
                SerializedProperty sibling = GetSiblingProperty(property, "_int");
                sibling.intValue = EditorGUI.IntField(position, sibling.intValue);
                GetSiblingProperty(property, "parameterType").enumValueIndex = 2;
            }
            else if (parameters[0].ParameterType == typeof(bool))
            {
                SerializedProperty sibling = GetSiblingProperty(property, "_bool");
                sibling.boolValue = EditorGUI.Toggle(position, sibling.boolValue);
                GetSiblingProperty(property, "parameterType").enumValueIndex = 0;
            }
        }


        // EditorGUI.PropertyField(position, property, label, true);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return target.Height;
    }
}
