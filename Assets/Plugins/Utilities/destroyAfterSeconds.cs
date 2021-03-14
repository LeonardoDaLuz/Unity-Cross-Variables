using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterSeconds : MonoBehaviour {
    public float seconds=5f;
    public float fadeOut = 0f;
	// Use this for initialization
	void OnEnable () {
       // print("START");
        UniversalObjectPooling.DesativateObjectAfterSeconds(gameObject, seconds);
        if (fadeOut != 0f)
        {
            var sr = GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.StopFades();
                sr.color = Color.white;
                this.StopAllCoroutines();
                this.DelayedCall(() => sr.FadeOut(fadeOut), seconds-fadeOut);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
