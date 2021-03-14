//Faz o get component automaticamente pela inspector, mto util.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetComponentHereAttribute : PropertyAttribute {

    public bool force;
    public bool hide;
    public float valueWidth;
    public float labelWidth;
    public GetComponentHereAttribute(bool force = false, bool _hide = false)
    {
        this.force = force;
        hide = _hide;
    }
    public GetComponentHereAttribute(bool force, float labelWidth, float valueWidth=0f)
    {
        this.force = force;
        this.labelWidth = labelWidth;
        this.valueWidth = valueWidth;
    }
}

