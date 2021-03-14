using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Util pra usar instantiate no animator, sem programar nada.
/// </summary>
public class InstantiateOnAnimationEvent : MonoBehaviour {
    public Transform target;
    public GameObject[] prefab;

    public void Instantiate(int index)
    {
        if (prefab == null)
            return;

        OriginReferenceInstantiator _ReferenceInstantiator = prefab[index].GetComponent<OriginReferenceInstantiator>();
        if (_ReferenceInstantiator != null)
        {
            _ReferenceInstantiator.SetOriginReference(target);
        }


        GameObject obj = (GameObject)Instantiate(prefab[index]);
        var InstantiatedColliders = obj.GetComponentsInChildren<Collider2D>();
        var myColliders = GetComponentsInChildren<Collider2D>();

        for (int i = 0; i < myColliders.Length; i++)
        {
            for (int ib = 0; ib < InstantiatedColliders.Length; ib++)
            {
                Physics2D.IgnoreCollision(myColliders[i], InstantiatedColliders[ib]);
            }
        }

        obj.transform.position = target.position;
        obj.transform.rotation = target.rotation;
        obj.transform.localScale = new Vector3(Mathf.Sign(transform.lossyScale.x) * Mathf.Sign(obj.transform.lossyScale.x) * Mathf.Abs(obj.transform.localScale.x), obj.transform.localScale.y, obj.transform.localScale.z);



    }
    public void InstantiateAndDestoyIt()
    {
        Instantiate(0);
        DestroyIt();
    }

    public void DestroyIt()
    {
        Destroy(gameObject);
    }

}

public interface OriginReferenceInstantiator
{
    void SetOriginReference(Transform origin);
}
