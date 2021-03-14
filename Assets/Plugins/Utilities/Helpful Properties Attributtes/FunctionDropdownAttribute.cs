//Cria uma drodownzinha com todas as states do animator
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GenericFunctionsPro;


#if UNITY_EDITOR
using UnityEditor.Animations;
using UnityEditor;
using System.Reflection;
using System;
#endif
/// <summary>
/// Specify the name of the variable that contains a script, the sibling fields with the names _bool, _float, _string, _int will be used as parameters.
/// </summary>
public class FunctionDropdownAttribute : PropertyAttribute
{
    public string scriptVariableName;
    public float Height;

	public FunctionDropdownAttribute(string _scriptVariableName)
    {
        this.scriptVariableName = _scriptVariableName;

    }
}


