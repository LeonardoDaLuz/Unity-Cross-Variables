using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapRotation : MonoBehaviour
{

    public float RotationSnap = 5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    Vector3 valueOnLastFrame;
    void FixedUpdate()
    {
        var eulerAngles = transform.eulerAngles;
        if (eulerAngles == valueOnLastFrame)
        {
            if ((eulerAngles.z < 360f && eulerAngles.z > 360f - RotationSnap) || (eulerAngles.z > 0f && eulerAngles.z < RotationSnap))
            {
                eulerAngles.z = 0f;
                transform.eulerAngles = eulerAngles;
            }
            if (eulerAngles.z < 180f + RotationSnap && eulerAngles.z > 180f - RotationSnap)
            {
                if (eulerAngles.z != 180f)
                {
                    eulerAngles.z = 180f;
                    transform.eulerAngles = eulerAngles;
                }
            }
        }
        valueOnLastFrame = eulerAngles;
    }
}
