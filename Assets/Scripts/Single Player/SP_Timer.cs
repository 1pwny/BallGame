using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

namespace singleplayer
{
    public class SP_Timer : Timer
    {
        public override void init()
        {
            /*
            manager = SP_GM.getManager();
            ((SP_GM)manager).register(this);
            // */
            seconds = 20;
            begin();
        }

        protected override void trigger(int sec)
        {
            if(sec == 30 || sec == 15)
            {
                manager.announce(sec + " seconds remaining!");
            }

            if(sec == 27 || sec == 12)
            {
                manager.announce("");
            }

            if(sec < 6)
            {
                manager.announce(sec+"");
            }
        }
    }
}