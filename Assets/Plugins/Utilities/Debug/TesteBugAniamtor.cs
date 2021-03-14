using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteBugAniamtor : MonoBehaviour {
    Animator animator;
    Rigidbody2D rigidbody;
    public bool UseRootMotion;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    Vector3 DeltaPosition;
    Quaternion DeltaRotation;
    void OnAnimatorMove()
    {
        animator.applyRootMotion = true;
        Debug.Log("hello");
    }
    //void OnAnimatorMove()
    //{
    //    if (UseRootMotion)
    //    {
    //        Vector3 delta = animator.deltaPosition;
    //        DeltaPosition += delta;
    //        DeltaRotation *= animator.deltaRotation;


    //    }
    //}
    void ManageRootMotion()
    {
        if (UseRootMotion)
        {
            rigidbody.simulated = true;
            Vector2 newPos = rigidbody.position;

                newPos += (Vector2)DeltaPosition;

            //rigidbody.gravityScale = -4f;
            rigidbody.MovePosition(newPos);
            //float convertTo2D = (Status.DeltaRotation * Vector3.forward).z;
            // Rb.MoveRotation((Rb.rotation* DeltaRotation)*Vector3.right);
            DeltaPosition = Vector3.zero;
            DeltaRotation = Quaternion.identity;
        }
    }


}
