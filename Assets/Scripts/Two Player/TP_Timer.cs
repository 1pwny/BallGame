using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;
using singleplayer;

namespace twoplayer
{
    public class TP_Timer : SP_Timer
    {
        public override void init()
        {
            seconds = 120;
            begin();
        }

        public void lowerTo(int sec)
        {
            if (seconds > sec)
                seconds = sec + 1;
        }

        protected override void trigger(int sec)
        {
            if(sec == 60)
            {
                manager.announce("One minute down, one left!");
            }
            base.trigger(sec);
        }
    }
}