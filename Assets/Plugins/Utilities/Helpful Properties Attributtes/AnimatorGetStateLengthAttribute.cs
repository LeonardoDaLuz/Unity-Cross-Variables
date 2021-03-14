using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class AnimatorGetStateLengthAttribute : PropertyAttribute
{
    public string _animatorVariableName;
    public int layer;
    public string variableNameWithStateName;
    public bool force;

    public AnimatorGetStateLengthAttribute(string variableNameWithStateName,string animatorVariableName = "", int layer=0, bool force = false)
    {
        this.variableNameWithStateName = variableNameWithStateName;
        this._animatorVariableName = animatorVariableName;
        this.layer = layer;
        this.force= force;
    }

    public AnimatorGetStateLengthAttribute(string variableNameWithStateName, bool force, string animatorVariableName = "", int layer = 0)
    {
        this.variableNameWithStateName = variableNameWithStateName;
        this._animatorVariableName = animatorVariableName;
        this.layer = layer;
        this.force = force;
    }
}
