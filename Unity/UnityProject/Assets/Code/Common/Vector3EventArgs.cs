using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Common
{
    public class Vector3EventArgs : EventArgs
    {
        public Vector3EventArgs(Vector3 vector)
        {
            this.Vector3 = vector;
        }

        public Vector3 Vector3 { get; private set; }
    }
}
