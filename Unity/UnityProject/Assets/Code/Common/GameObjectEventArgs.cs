using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Common
{
    public class GameObjectEventArgs : EventArgs
    {
        public GameObjectEventArgs(GameObject current)
        {
            this.Current = current;
        }

        public GameObject Current { get; private set; }
    }
}
