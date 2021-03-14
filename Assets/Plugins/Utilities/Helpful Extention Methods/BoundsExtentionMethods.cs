using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoLuz
{
    public static class BoundsExtensions
    {
        //public static bool Contains(this Bounds bounds, Vector3 RelativeTo, LayerMask layerMask, bool facingRight, bool hilightArea, Color color)
        //{
        //    bool result = Physics2D.OverlapArea(RelativeTo + (facingRight ? bounds.min : new Vector3(-bounds.min.x, bounds.min.y, 0)), RelativeTo + (facingRight ? bounds.max : new Vector3(-bounds.max.x, bounds.max.y, 0f)), layerMask);
        //    if (result == true)
        //    {
        //        if (hilightArea)
        //            bounds.DrawBox(RelativeTo, color, 3f);
        //        return true;
        //    }
        //    else
        //    {
        //        if (hilightArea)
        //        {
        //            color.a = 0.2f;
        //            bounds.DrawBox(RelativeTo, color, 1f);
        //        }
        //        return false;
        //    }
        //}
        public static void DrawBox(this Bounds bounds, Vector3 RelativeTo, bool flipX, Color color, float duration)
        {
            Vector3 max= bounds.max;
            Vector3 min= bounds.min;
            Vector3 center = bounds.center;
            if (flipX)
            {
                max.x = -max.x;
                min.x = -min.x;
                center.x = -center.x;
            }
             
            Debug.DrawLine(RelativeTo + min, RelativeTo + new Vector3(min.x, max.y),color, duration);
            Debug.DrawLine(RelativeTo + new Vector3(min.x, max.y), RelativeTo + max,color, duration);
            Debug.DrawLine(RelativeTo + max, RelativeTo + new Vector3(max.x, min.y),color, duration);
            Debug.DrawLine(RelativeTo + new Vector3(max.x, min.y), RelativeTo + min,color, duration);
        }

    }
}