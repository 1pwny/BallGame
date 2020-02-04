using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

namespace singleplayer
{
    public class SP_CM : PickupManager
    {

        SP_GM overlord;

        // Start is called before the first frame update
        void Start()
        {
            overlord = SP_GM.getManager();
            overlord.register(this);
        }

        public int left()
        {
            return collectibles.Count;
        }

        protected override void initCollectibles()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}