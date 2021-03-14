using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorExtensionMethods
{

    /// <summary>
    /// Faz o crossfade e quando a animação termina ele chama a função callback
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="name"></param>
    /// <param name="transitionDuration"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    public static void CrossFade(this Animator animator, string name, float transitionDuration, MonobehaviourMethods.GenericMethod callBack)
    {
        animator.CrossFade(name, transitionDuration);
        animator.GetComponent<MonoBehaviour>().StartCoroutine(WaitAnimationEnd(animator, transitionDuration, callBack));
    }
    private static IEnumerator WaitAnimationEnd(Animator animator, float transitionDuration, MonobehaviourMethods.GenericMethod callBack)
    {

        yield return new WaitForEndOfFrame();
        if(transitionDuration!=0f)
            yield return new WaitForSeconds(transitionDuration);

        //Debug.Log("duration: " + animator.GetCurrentAnimatorStateInfo(0).length);
        var nameHash = animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        if(nameHash == animator.GetCurrentAnimatorStateInfo(0).fullPathHash)
            callBack();
    }



}