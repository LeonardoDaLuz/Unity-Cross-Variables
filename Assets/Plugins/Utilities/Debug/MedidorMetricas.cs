using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedidorMetricas : MonoBehaviour {
    public Vector2 RigidbodyVelocity;
    public Vector2 TransformVelocity;
    public Vector2 TilesPersecond;
    public float TilesSize;
    public float GravityVelocityLimit = 25f;
    private Rigidbody2D rb;
    Vector3 positionOnLastFrame;
    bool breaked;
    float gravityStartTime;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (rb.velocity.y >-0.000001f)
        {
            gravityStartTime = Time.time;
        }
        if(gravityStartTime != -Mathf.Infinity && rb.velocity.y< GravityVelocityLimit)
        {
            rb.velocity = new Vector2(rb.velocity.x, GravityVelocityLimit);
            print("reached gravity limit in: " + (Time.time - gravityStartTime));
            gravityStartTime = -Mathf.Infinity;
        }
    }
    // Update is called once per frame
    void Update () {
        if (!breaked)
        {
            TransformVelocity = (transform.position - positionOnLastFrame) / Time.deltaTime;
            RigidbodyVelocity = rb.velocity;
            TilesPersecond = (TransformVelocity / TilesSize);
            positionOnLastFrame = transform.position;
        }
        if (Input.GetKeyDown("i"))
        {
            Debug.Break();
            breaked = true;
        }
	}
}
