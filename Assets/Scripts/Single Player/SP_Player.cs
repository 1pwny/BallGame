using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

namespace singleplayer
{
    public class SP_Player : Player
    {
        public SP_GM manager;

        protected override void init()
        {
            manager = SP_GM.getManager();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collectable"))
            {
                manager.score(other);
            }
        }
    }
}