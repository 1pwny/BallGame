using Basics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SP_VT : VictoryText
{
    public override void sendVictoryMessage()
    {
        base.sendVictoryMessage();
    }

    public void sendVictoryMessage(int time)
    {
        myself.text = "Congratulations! You won with " + time + " seconds left!";
    }
}
