using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SpriteExtensions
{
    /// <summary>
    /// Compare if this layerNumber is in layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
	public static WaitForSeconds FadeIn(this SpriteRenderer obj, float duration)
    {
        var handler = obj.GetComponent<SpriteFadesHandler>();
        if (handler == null)
            handler = obj.gameObject.AddComponent<SpriteFadesHandler>();

        handler.FadeIn(obj, duration);
		return new WaitForSeconds(duration);
    }



	public static WaitForSeconds FadeOut(this SpriteRenderer obj, float duration)
	{
        var handler = obj.GetComponent<SpriteFadesHandler>();
        if (handler == null)
            handler = obj.gameObject.AddComponent<SpriteFadesHandler>();

        handler.FadeOut(obj, duration);
		return new WaitForSeconds(duration);
	}

    public static void StopFades(this SpriteRenderer obj)
    {
        var handler = obj.GetComponent<SpriteFadesHandler>();
        if (handler == null)
            handler = obj.gameObject.AddComponent<SpriteFadesHandler>();

        handler.StopFading(obj);
    }

    public static void SetAlpha(this SpriteRenderer obj, float alpha)
    {
        Color color = obj.color;
        color.a = alpha;
        obj.color = color;
    } 
}
public class SpriteFadesHandler: MonoBehaviour
{
    Coroutine coroutine;

    public void StopFading(SpriteRenderer obj)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    public void FadeOut(SpriteRenderer obj, float duration)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine=StartCoroutine(FadeOutCo(obj, duration));
    }
    public static IEnumerator FadeOutCo(SpriteRenderer obj, float duration)
    {
        float t = duration;
        obj.SetAlpha(1f);
        while (t > 0f)
        {
            t -= Time.fixedDeltaTime;
            obj.SetAlpha(t / duration);
            yield return new WaitForEndOfFrame();
        }
        obj.SetAlpha(0f);
    }

    public void FadeIn(SpriteRenderer obj, float duration)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(FadeInCo(obj, duration));
    }

    public static IEnumerator FadeInCo(SpriteRenderer obj, float duration)
    {
        float t = 0f;
        obj.SetAlpha(0f);
        while (t < duration)
        {
            t += Time.fixedDeltaTime;
            obj.SetAlpha(t / duration);
            yield return new WaitForEndOfFrame();
        }
        obj.SetAlpha(1f);
    }
}