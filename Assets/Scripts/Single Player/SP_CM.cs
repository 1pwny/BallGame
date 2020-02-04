using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

namespace singleplayer
{
    public class SP_CM : PickupManager
    {

        public SP_GM manager;

        

        public int left()
        {
            return collectibles.Count;
        }

        protected override void initCollectibles()
        {
            manager.setMax(collectibles.Count);
            manager.updateboard();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}