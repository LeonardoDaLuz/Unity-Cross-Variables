using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Faz Shake na camera, pode vir a não funcionar devido a sobreposições de ordem
/// </summary>
public class Shake : MonoBehaviour {
    public Vector3 ShakeDir = Vector3.left;
    public AnimationCurve ShakeCurve;
    public float duration = 1f;
    public static Shake i;
    public bool ShakeNow;
	// Use this for initialization
	void Start () {
        i = this;
    }
	
	// Update is called once per frame
	void Update () {
        if (ShakeNow)
        {
            ShakeNow = false;
            shake();
        }
	}

    public void shake()
    {
        StartCoroutine(ShakeCo());
    }
    public IEnumerator ShakeCo()
    {

        float t = 0f;
        Vector3 initialPosition = transform.position;
        while (t< duration)
        {
            t += Time.deltaTime;
            transform.position = initialPosition + (ShakeDir * ShakeCurve.Evaluate(t));
            yield return new WaitForEndOfFrame();
        }
        transform.position= initialPosition;
    }
}
