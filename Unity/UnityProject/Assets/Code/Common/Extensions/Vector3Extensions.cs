using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Common.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 ApplyDeltaTime(this Vector3 v3)
        {
            v3.Set(v3.x * Time.deltaTime, v3.y * Time.deltaTime, v3.z * Time.deltaTime);

            return v3;
        }
    }
}
