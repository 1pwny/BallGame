using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

namespace twoplayer
{
    public class TP_CM : PickupManager
    {
        public TP_GM manager;



        public int left()
        {
            return collectibles.Count;
        }

        protected override void initCollectibles()
        {
            manager.updateboard();
        }
    }
}