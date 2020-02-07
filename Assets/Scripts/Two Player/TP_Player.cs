using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

namespace twoplayer
{
    public class TP_Player : Player
    {
        public TP_GM manager;
        public int playernum;

        private int invincibility;

        protected override void init()
        {
            invincibility = 0;

            if (playernum == 0)
                this.kbs = Overlord.p1;
            else
                this.kbs = Overlord.p2;
        }

        private void Update()
        {
            if (invincibility > 0)
                invincibility--;
        }

        protected void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                manager.penalize(playernum);
            }
            if(collision.collider.CompareTag("Player") && invincibility == 0)
            {
                float myY = transform.position.y, theirY = collision.collider.transform.position.y;
                if (myY > theirY)
                    manager.score(playernum);
                else if (myY < theirY)
                    manager.penalize(playernum);

                invincibility = 10;
            }
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collectable"))
            {
                manager.score(playernum, other);
            }
        }
    }
}