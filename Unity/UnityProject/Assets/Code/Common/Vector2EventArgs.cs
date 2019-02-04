using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Common
{
    public class Vector2EventArgs : EventArgs
    {
        public Vector2EventArgs(Vector2 vector)
        {
            this.Vector2 = vector;
        }

        public Vector2 Vector2 { get; private set; }
    }
}
