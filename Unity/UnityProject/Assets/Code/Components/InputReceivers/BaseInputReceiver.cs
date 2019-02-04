using Assets.Code.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Components.InputReceivers
{
    public abstract class BaseInputReceiver : MonoBehaviour
    {
        public abstract event EventHandler<Vector2EventArgs> MoveInputReceived;
        public abstract event EventHandler<Vector3EventArgs> FireInputReceived;
        public abstract event EventHandler<Vector3EventArgs> ArrowInputReceived;

        public abstract void Update();

        public abstract void FixedUpdate();
    }
}
