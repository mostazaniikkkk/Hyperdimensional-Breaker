using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public static class Pariente
    {
        public static Vector3 realScale(Transform obj)
        {
            Vector3 scale = obj.localScale;
            while (obj.parent != null)
            {
                obj = obj.parent;
                scale.x *= obj.localScale.x;
                scale.y *= obj.localScale.y;
                scale.z *= obj.localScale.z;
            }

            return scale;
        }
    }
}