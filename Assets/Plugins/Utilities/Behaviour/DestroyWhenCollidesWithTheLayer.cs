using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenCollidesWithTheLayer : MonoBehaviour {
    public LayerMask layer;
    public float delay;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (layer.Contains(collision.gameObject.layer)){
            Destroy(gameObject, delay);

          //  print("EPPPPAA");
        }
    }
}
