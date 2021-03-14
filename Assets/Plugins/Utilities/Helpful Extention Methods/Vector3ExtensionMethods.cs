using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static void ScaleX(this Transform _vector, float value)
    {
        var scale = _vector.localScale;
        scale.x = value;
        _vector.localScale = scale;
    }
    public static void ScaleXSign(this Transform _vector, float Sign)
    {
        var scale = _vector.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(Sign);
        _vector.localScale = scale;
    }

    public static void LossyScaleXSign(this Transform _vector, float Sign)
    {
        var scale = _vector.localScale;
        if (Mathf.Sign(_vector.lossyScale.x) != Sign)
        {
            scale.x = scale.x * -1f;
            _vector.localScale = scale;
        }
    }
    public static void InvertScaleX(this Transform _vector)
    {
        var scale = _vector.localScale;
        scale.x *= -1f;
        _vector.localScale = scale;
    }

    public static void ZoomIn(this Transform transform, float Scale = 1f, float duration = 0.5f, float XSign = 1f)
    {
        transform.gameObject.SetActive(true);
        transform.GetComponent<MonoBehaviour>().StartCoroutine(ZoomInCo(transform, Scale, duration, XSign));
    }

    private static IEnumerator ZoomInCo(Transform transform, float Scale = 1f, float duration = 0.5f, float XSign = 1f)
    {
        float t = 0f;
        var targetScale = Vector3.one * Scale;

        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, t / duration);
            transform.LossyScaleXSign(XSign);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = targetScale;
        transform.LossyScaleXSign(XSign);

    }

    public static void ZoomOut(this Transform transform, float duration)
    {
        if (!transform.gameObject.activeInHierarchy)
            return;
        transform.GetComponent<MonoBehaviour>().StartCoroutine(ZoomOutCo(transform, duration));
    }

    private static IEnumerator ZoomOutCo(Transform transform, float duration)
    {

        float t = 0f;
        Vector3 initialScale = transform.localScale;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t / duration);
            yield return new WaitForEndOfFrame();
        }
        transform.localScale = Vector3.zero;
        transform.gameObject.SetActive(false);
    }
}