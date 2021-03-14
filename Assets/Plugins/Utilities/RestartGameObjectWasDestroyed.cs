using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartGameObjectWasDestroyed : MonoBehaviour {

    public GameObject Observed;
	
	// Update is called once per frame
	void Update () {
        if (Observed == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}
