using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(5f, 5f, 5f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().material.color = new Color(0f, 0f, 0f, 1f);
    }
}
