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
            //this. kbs = new KeyBinds(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.LeftShift);
            this.kbs = Overlord.p1;
            /*
            manager = SP_GM.getManager();
            manager.register(this);
            // */
        }

        protected void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                manager.penalize();
            }
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