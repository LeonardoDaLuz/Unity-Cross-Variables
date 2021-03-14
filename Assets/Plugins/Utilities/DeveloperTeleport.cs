using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperTeleport : MonoBehaviour
{

	#if UNITY_EDITOR
    public GameObject player;
    public bool activate;
    public bool desactivate;// Use this for initialization
    private void OnDrawGizmosSelected()
    {
        if (activate)
        {
            PlayerPrefs.SetInt("UseDeveloperTeleport", 1);
            activate = false;
        }
        if (desactivate)
        {
            PlayerPrefs.SetInt("UseDeveloperTeleport", 0);
            desactivate = false;
        }
    }
    void Start()
    {
        if(PlayerPrefs.HasKey("UseDeveloperTeleport") && PlayerPrefs.GetInt("UseDeveloperTeleport") == 1)
        {
            player.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            player.transform.position = transform.position;
			

        }
    }
	#endif
}
