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

public class AnimatorStatesDropdownAttribute : PropertyAttribute
{
    public string _animatorVariableName;
    public int layer;

	public AnimatorStatesDropdownAttribute(string animatorVariableName, int layer = 0)
    {
        this._animatorVariableName = animatorVariableName;
        this.layer = layer;
    }

    public AnimatorStatesDropdownAttribute(int layer = 0)
    {
        this._animatorVariableName = "";
        this.layer = layer;
    }

}


