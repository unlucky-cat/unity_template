using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Code.Components.HitReceivers
{
    class DestructiveHitReceiver : BaseHitReceiver
    {
        public override void ReceiveHit()
        {
            var obj = this.gameObject;

            //var restarter = obj.GetComponent<GameRestarter>();
            //if (restarter != null) restarter.RestartTheGame();

            base.ReceiveHit();
            UnityEngine.Object.Destroy(obj, 0.5f);

        }
    }
}
