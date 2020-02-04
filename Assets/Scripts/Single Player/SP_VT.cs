using Basics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace singleplayer
{

    public class SP_VT : VictoryText
    {
        

        public void sendVictoryMessage(int time)
        {
            myself.text = "Congratulations! You won with " + time + " seconds left!";
        }
    }
}