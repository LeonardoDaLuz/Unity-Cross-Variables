using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class RigidbodyExtensionMethods
{
    public static void VelocityX(this Rigidbody2D rigidbody, float velocityX)
    {
        var vel = rigidbody.velocity;
        vel.x = velocityX;
        rigidbody.velocity = vel;
    }
}