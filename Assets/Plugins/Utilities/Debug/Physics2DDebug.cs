using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics2DDebug  {

    public static bool debug;

    public static RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, LayerMask layer)
    {
        var col = Physics2D.Raycast(origin, direction, distance, layer);
        if (col.collider!=null)
        {
            if (debug)
                Debug.DrawLine(origin, col.point, Color.green, 0.2f);
        } else {
            if (debug)
                Debug.DrawRay(origin, direction*distance, Color.red, 0.2f);
        }
        return col;
    }
    public static void DebugOverlapArea(Vector2 a, Vector2 b, Color color, float time = 3f, float alpha = 0.1f)
    {
        color.a = alpha;
        Debug.DrawLine(a, new Vector2(a.x, b.y), color, time);
        Debug.DrawLine(new Vector2(a.x, b.y), b, color, time);
        Debug.DrawLine(b, new Vector2(b.x, a.y), color, time);
        Debug.DrawLine(new Vector2(b.x, a.y), a, color, time);

    }

    public static void DebugBounds(Bounds bounds, Color color, float time = 3f, float alpha = 0.1f)
    {
        color.a = alpha;
        var a = bounds.min;
        var b = bounds.max;
        DebugOverlapArea(a, b, color, time, alpha);
    }

    public static void DebugOverlapArea(Vector3 position, float radius, Color color, float duration = .16f)
    {
        Quaternion rotation=new Quaternion();
        Vector3 a = (rotation * (Vector3.right * radius)) + position;
        for (int i = 0; i < 10f; i++)
        {
            var angles = rotation.eulerAngles;
            angles.z += 36f;
            rotation.eulerAngles = angles;
            Vector3 b = (rotation*(Vector3.right* radius))+ position;
            Debug.DrawLine(a, b, Color.red, 5f);
            a = b;
        }
    }
}
