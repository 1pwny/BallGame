using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;

public class SP_Player : Player
{
    public SP_Manager manager;

    protected override void score()
    {
        manager.score();
    }
}
