using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMathTests : MonoBehaviour {
    public Vector3 Vector;
    public Transform Child;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called o

	void Update () {
        Vector3 rotatedPosition = (transform.rotation * Vector);
        rotatedPosition = Quaternion.Inverse(transform.rotation) * rotatedPosition;
        Child.position = transform.position + rotatedPosition;
	}
}
