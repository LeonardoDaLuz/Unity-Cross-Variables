using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionBoxAttribute : PropertyAttribute
{
    public string text;
    public float height;
    public float PropertyHeight;
    public bool hideProperty;

    public DescriptionBoxAttribute(string _text, float _height = 64f, float _PropertyHeight = 16f, bool _hideProperty=false)
    {
        text = _text;
        height = _height;
        PropertyHeight = _PropertyHeight;
        hideProperty = _hideProperty;
    }
}
