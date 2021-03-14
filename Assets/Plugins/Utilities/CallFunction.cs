using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CallFunction {
    [GetComponentHere]
    public MonoBehaviour script;
    [FunctionDropdown("script")]
    public string Function;
    public enum ParameterType { _bool, _float, _int, _string }
    [HideInInspector]
    public ParameterType parameterType;
    [HideInInspector]
    public string _string;
    [HideInInspector]
    public float _float;
    [HideInInspector]
    public bool _bool;
    [HideInInspector]
    public int _int;
    public float Delay;  

    public void Call(bool debug)
    {
        //  Debug.Log("Call");
        if (debug)
        {
            if (Delay > 0f)
            {
                Debug.Log(script.gameObject.name+".Delayed Function Call: " + Function + "will started in" + Delay);
            }
            else
            {
                Debug.Log(script.gameObject.name + ".Function Call: " + Function + "will started in" + Delay);
            }
        }
        switch (parameterType)
        {
            case ParameterType._bool:
                if (Delay == 0f)
                    script.SendMessage(Function, _bool);
                else
                    script.StartCoroutine(DelayedCall(Function, _bool, Delay));

                break;
            case ParameterType._float:
                if (Delay == 0f)
                    script.SendMessage(Function, _float);
                else
                    script.StartCoroutine(DelayedCall(Function, _float, Delay));
                break;
            case ParameterType._int:
                if (Delay == 0f)
                    script.SendMessage(Function, _int);
                else
                    script.StartCoroutine(DelayedCall(Function, _int, Delay));
                break;
            case ParameterType._string:
                if (Delay == 0f)
                    script.SendMessage(Function, _string);
                else
                    script.StartCoroutine(DelayedCall(Function, _string, Delay));

                break;
            default:
                break;
        }
    }

    public IEnumerator DelayedCall(string function, object parameter, float delay)
    {
      //  Debug.Log("DelayedCall 0");
        yield return new WaitForSeconds(delay);
        script.SendMessage(Function, parameter);
      //  Debug.Log("DelayedCall 1");
    }

    public static void CallAll(CallFunction[] all, bool debug=false)
    {
        for (int i = 0; i < all.Length; i++)
        {
            all[i].Call(debug);
        }
    }
}
