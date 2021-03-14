using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


[System.Serializable]
public class xBoolData
{
    public bool value;
    public string varName;
    public bool sincronizeAnimatorParameter;
    public string variablePath;
    public MonoBehaviour script;
}
[System.Serializable]
public class xbool
{
    public int xIndex;
    public XBrain xBrain;
    [System.NonSerialized]
    public bool optimized;
    [System.NonSerialized]
    public xBoolData x;
    public static implicit operator bool(xbool d)
    {
        return d.xBrain.xBoolList[d.xIndex].value;
    }
    /// <summary>
    ///  Set Xbool variable, disregarding Animator sincronization witch animator, if you want animator sincronization use this.Set(bool value);
    /// </summary>
    public bool val
    {
        get
        {
            return xBrain.xBoolList[xIndex].value;
        }
        set
        {
            xBrain.xBoolList[xIndex].value = value;

        }
    }

    public void Optimize()
    {
        x = xBrain.xBoolList[xIndex];
    }
    /// <summary>
    /// Set Xbool variable, considering Animator sincronization witch animator, if you do not want animator sincronization use this.val = value;
    /// </summary>
    public void Set(bool value)
    {
        var _xbool = xBrain.xBoolList[xIndex];
        _xbool.value = value;

        if (_xbool.sincronizeAnimatorParameter && Application.isPlaying)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                return;

            if (xBrain.animator == null)
            {
                return;
            }
#endif
            xBrain.animator.SetBool(_xbool.varName, value);

        }

    }
}

[System.Serializable]
public class xTbool
{
    public int xIndex;
    public XBrain xBrain;
    [System.NonSerialized]
    public bool optimized;
    [System.NonSerialized]
    public xBoolData xboolData;
    /// <summary>
    ///  Set Xbool variable, disregarding Animator sincronization witch animator, if you want animator sincronization use this.Set(bool value);
    /// </summary>
    public bool val
    {
        set
        {
            xboolData.value = value;

        }
    }
    /// <summary>
    /// Set Xbool variable, considering Animator sincronization witch animator, if you do not want animator sincronization use this.val = value;
    /// </summary>
    public void Set(bool value)
    {
        xboolData.value = value;
    }
}
[System.Serializable]
public class xfloat
{
    public int xIndex;
    public XBrain xBrain;

    public static implicit operator float(xfloat d)
    {
        return d.xBrain.xFloatList[d.xIndex].value;
    }
    /// <summary>
    ///  Set xfloat variable, disregarding Animator sincronization witch animator, if you want animator sincronization use this.Set(bool value);
    /// </summary>
    public float val
    {
        get
        {
            return xBrain.xFloatList[xIndex].value;
        }
        set
        {
            xBrain.xFloatList[xIndex].value = value;
        }
    }
    /// <summary>
    /// Set xfloat variable, considering Animator sincronization witch animator, if you do not want animator sincronization use this.val = value;
    /// </summary>
    public void Set(float value)
    {
        var xFloatData = xBrain.xFloatList[xIndex];
        if (xFloatData.sincronizeAnimatorParameter && Application.isPlaying)
        {
#if UNITY_EDITOR
            if (xBrain.animator == null)
            {
                Debug.LogError("You are using a variable that needs to use the animator, please add an animator to the " + xBrain.gameObject.name + ".");
            }
#endif
            xBrain.animator.SetFloat(xFloatData.varName, value);

        }
        xFloatData.value = value;

    } 
}

[System.Serializable]
public class xint
{
    public int xIndex;
    public XBrain xBrain;

    public static implicit operator int(xint d)
    {
        return d.xBrain.xIntList[d.xIndex].value;
    }

    /// <summary>
    ///  Set xfloat variable, disregarding Animator sincronization witch animator, if you want animator sincronization use this.Set(bool value);
    /// </summary>
    public int val
    {
        get
        {
            return xBrain.xIntList[xIndex].value;
        }
        set
        {
            xBrain.xIntList[xIndex].value = value;
        }
    }
    /// <summary>
    /// Set xfloat variable, considering Animator sincronization witch animator, if you do not want animator sincronization use this.val = value;
    /// </summary>
    public void Set(int value)
    {
        var xIntData = xBrain.xIntList[xIndex];
        xIntData.value = value;

        if (xIntData.sincronizeAnimatorParameter && Application.isPlaying)
        { 
#if UNITY_EDITOR
            if (xBrain.animator == null)
            {
                return;
                Debug.LogError("You are using a variable that needs to use the animator, please add an animator to the " + xBrain.gameObject.name + ".");
            }
#endif
            xBrain.animator.SetInteger(xIntData.varName, value);

        }

    }
}