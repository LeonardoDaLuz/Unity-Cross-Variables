using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationAfterSeconds : MonoBehaviour {
    public float waitTime=5f;
    public MonoBehaviour[] DisableScripts;
    float expireTime;
    [AnimatorStatesDropdown]
    public string _animation;
	// Use this for initialization
	void Start () {
        expireTime = Time.time + waitTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > expireTime)
        {
            for (int i = 0; i < DisableScripts.Length; i++)
            {
                DisableScripts[i].enabled = false;
            }
            GetComponent<Animator>().CrossFade(_animation, 0f);
        }
	}

    public void DestroyIt()
    {
        Destroy(gameObject);
    }
}
