using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Linq.Expressions;

public static class MonobehaviourMethods
{
    public delegate void GenericMethod();
    public delegate bool GenericMethod2<T>(MonoBehaviourExtended<T> n);
    public delegate bool GenericMethod5();

    public static IEnumerator DelayedCallRealtimeCo(GenericMethod method, float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        method();
    }
    public static IEnumerator DelayedCallCo(GenericMethod method, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        method();
    }
    public static void DelayedCallRealTime(this MonoBehaviour mono, GenericMethod method, float waitTime)
    {
        mono.StartCoroutine(DelayedCallRealtimeCo(method, waitTime));
    }

    public static void DelayedCall(this MonoBehaviour mono, GenericMethod method, float waitTime)
    {
        mono.StartCoroutine(DelayedCallRealtimeCo(method, waitTime));
    }


    //   public delegate bool GenericMethod3<T>(T n);
    // public delegate bool GenericMethod4<T>(CallablePanel<T> n);

    //Chama o metodo, espera uma variavel estar como desejado e chama outro metodo devolta
    public static void CallWaitClausuleAndCallBack(this MonoBehaviour mono, GenericMethod CallMethod, GenericMethod5 callbackClausule, GenericMethod callBack)
    {
        mono.StartCoroutine(CallWaitAndCallBackCo(CallMethod, callbackClausule, callBack));
    }

    public static IEnumerator CallWaitAndCallBackCo(GenericMethod CallMethod, GenericMethod5 callbackClausule, GenericMethod callBack)
    {
        CallMethod();
        while (!callbackClausule())
        {
            yield return new WaitForFixedUpdate();
        }
        callBack();
    }

    public static void WaitClausuleAndCall(this MonoBehaviour mono, GenericMethod5 callbackClausule, GenericMethod callBack)
    {
        mono.StartCoroutine(WaitClausuleAndCallCo(callbackClausule, callBack));
    }
    public static IEnumerator WaitClausuleAndCallCo(GenericMethod5 callbackClausule, GenericMethod callBack)
    {
        while (!callbackClausule())
        {
            yield return new WaitForFixedUpdate();
        }
        callBack();
    }

}
public class MonoBehaviourExtended<T> : MonoBehaviour
{

}