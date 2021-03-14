using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyAnimationEvents : MonoBehaviour {

    [GetComponentHere]
    public Rigidbody2D rb;

	public void SetGravity(float gravityScale)
    {
        rb.gravityScale = gravityScale;
    }
}
