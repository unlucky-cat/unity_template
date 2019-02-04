using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Common;
using UnityEngine;

namespace Assets.Code.Components.InputReceivers
{
    public class AltKeyboardInputReceiver : BaseInputReceiver
    {
        public override event EventHandler<Vector2EventArgs> MoveInputReceived;
        public override event EventHandler<Vector3EventArgs> FireInputReceived;
        public override event EventHandler<Vector3EventArgs> ArrowInputReceived;

        private float dX;
        private float dY;

        public override void FixedUpdate()
        {
            MoveInputReceived?.Invoke(this, new Vector2EventArgs(new Vector2(dX, dY)));
        }

        public override void Update()
        {
            dX = Input.GetAxisRaw("Horizontal");
            dY = Input.GetAxisRaw("Vertical");
        }
    }
}