using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

public class SP_Timer : Timer
{
    public override void init()
    {
        seconds = 15;
        begin();
    }
}
