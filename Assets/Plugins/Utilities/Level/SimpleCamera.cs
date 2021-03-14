using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour {
    public float HorizontalFollow=10f;
    public float VerticalFollow=5f;
    public Transform Target;
    public Vector3 Offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var camPos = transform.position;
        camPos.z = Offset.z;
        camPos.x = Mathf.Lerp(camPos.x, Target.position.x+Offset.x, HorizontalFollow*Time.deltaTime);
        camPos.y = Mathf.Lerp(camPos.y, Target.position.y+Offset.y, VerticalFollow *Time.deltaTime);
        transform.position = camPos;

    }
}
