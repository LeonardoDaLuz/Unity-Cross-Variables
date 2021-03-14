//Funciona como componente em um UI.Text, basta jogar la, e dar referência.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPSConter : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Application.targetFrameRate = 60;
        text.text = ((int)(1f / Time.deltaTime)).ToString();
	}
}
