using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodedInstantiationAnimationEvent : MonoBehaviour {
    public Transform target;
    public GameObject[] prefabs;
    public Vector2 MinSpeed;
    public Vector2 MaxSpeed;


    public void InstantiateAllExplosively()
    {
        if (prefabs == null)
            return;

        for (int i = 0; i < prefabs.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(prefabs[i], target.position, target.rotation);
            obj.transform.position = target.position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.localScale = new Vector3(Mathf.Sign(transform.lossyScale.x) * Mathf.Sign(obj.transform.lossyScale.x) * Mathf.Abs(obj.transform.localScale.x), obj.transform.localScale.y, obj.transform.localScale.z);
            Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
            objRb.velocity = new Vector2(Random.Range(MinSpeed.x, MaxSpeed.x), Random.Range(MinSpeed.y, MaxSpeed.y));
        }
    }
    public void InstantiateAllExplosivelyAndDestoyIt()
    {
        InstantiateAllExplosively();
        DestroyIt();
    }
    public void DestroyIt()
    {
        Destroy(gameObject);
    }
}
