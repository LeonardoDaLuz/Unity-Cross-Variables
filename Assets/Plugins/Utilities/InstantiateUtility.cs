using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUtility : MonoBehaviour
{
    public static InstantiateUtility instance
    {
        get
        {
            if (Instance == null)
            {
                var obj = new GameObject();
                Instance = obj.AddComponent<InstantiateUtility>();
            }

            return Instance;
        }
    }

    private static InstantiateUtility Instance;


    public void InstantiateWithDelay(GameObject prefab, Vector3 position, Quaternion rotation, float delay, GameObject ignoreCollisionWith)
    {
        if (delay == 0f)
            GoInstantiate(prefab, position, rotation, ignoreCollisionWith);
        else
            StartCoroutine(DelayedInstantiateCo(prefab, position, rotation, delay, ignoreCollisionWith));
    }

    private static void GoInstantiate(GameObject prefab, Vector3 position, Quaternion rotation, GameObject ignoreCollisionWith)
    {
        GameObject obj = Instantiate(prefab, position, rotation);
        if (ignoreCollisionWith.transform.localScale.x < 0f)
        {
            var scale = obj.transform.localScale;
            scale.x *= -1f;
            obj.transform.localScale = scale;
        }

        var ObjCols = obj.GetComponentsInChildren<Collider2D>();
        var emissorCols = ignoreCollisionWith.GetComponentsInChildren<Collider2D>();

        for (int i = 0; i < ObjCols.Length; i++)
        {
            for (int ib = 0; ib < emissorCols.Length; ib++)
            {
                Physics2D.IgnoreCollision(ObjCols[i], emissorCols[ib]);
            }
        }

    }
    public static IEnumerator DelayedInstantiateCo(GameObject prefab, Vector3 position, Quaternion rotation, float delay, GameObject ignoreCollisionWith)
    {
        yield return new WaitForSeconds(delay);
        GoInstantiate(prefab, position, rotation, ignoreCollisionWith);
    }



    [System.Serializable]
    public class DelayedInstantiate
    {
        [GetComponentHere]
        public Transform Target;
        public GameObject prefab;
        public float Delay;

        public void Instantiate(GameObject ignoreCollisionWith = null)
        {
			OriginReferenceInstantiator _ReferenceInstantiator = prefab.GetComponent<OriginReferenceInstantiator>();
			if (_ReferenceInstantiator != null)
			{
				_ReferenceInstantiator.SetOriginReference(Target);
			}
            InstantiateUtility.instance.InstantiateWithDelay(prefab, Target.position, Target.rotation, Delay, ignoreCollisionWith);
        }

    }
}
