using Assets.Code.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Common.Extensions
{
    public static class Vector2Extensions
    {
        public static MovingController.FacingState ToFacingState(this Vector2 v2)
        {
            MovingController.FacingState fs;

            if (v2.x > 0) fs = MovingController.FacingState.Right;
            else if (v2.x < 0) fs = MovingController.FacingState.Left;
            else if (v2.y > 0) fs = MovingController.FacingState.Back;
            else if (v2.y < 0) fs = MovingController.FacingState.Direct;
            else fs = MovingController.FacingState.None;

            return fs;
        }

        public static Vector2 ApplyDeltaTime(this Vector2 v2)
        {
            v2.Set(v2.x * Time.deltaTime, v2.y * Time.deltaTime);

            return v2;
        }

        public static Vector2 ApplyFixedDeltaTime(this Vector2 v2)
        {
            v2.Set(v2.x * Time.fixedDeltaTime, v2.y * Time.fixedDeltaTime);

            return v2;
        }
    }
}
