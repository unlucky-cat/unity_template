using Assets.Code.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Common.Extensions
{
    public static class FacingStateExtensions
    {
        public static Vector2 ToVector2(this MovingController.FacingState fs)
        {
            switch (fs)
            {
                case MovingController.FacingState.Left:
                    return new Vector2(-1, 0);
                case MovingController.FacingState.Right:
                    return new Vector2(1, 0);
                case MovingController.FacingState.Direct:
                    return new Vector2(0, -1);
                case MovingController.FacingState.Back:
                    return new Vector2(0, 1);
                case MovingController.FacingState.None:
                default:
                    return new Vector2(0, 0);
            }
        }
    }
}
