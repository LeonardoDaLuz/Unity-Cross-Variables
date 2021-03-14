using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefletScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.lossyScale.x < 0f) {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
	}
}
