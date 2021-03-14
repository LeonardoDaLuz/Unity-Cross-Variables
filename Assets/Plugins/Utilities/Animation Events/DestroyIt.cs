using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIt : MonoBehaviour {
    public bool pooling=true;
	public void destroyIt()
    {
        if (pooling)
        {
            gameObject.SetActive(false);
        } else
        {
            Destroy(gameObject);
        }
    }
    public void destroyItAndParent()
    {
        if (pooling)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
