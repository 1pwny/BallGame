using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinds
{
    public KeyCode up, left, down, right, jump;
    public bool ismouse;

    public KeyBinds()
    {
        ismouse = true;
    }

    public KeyBinds(KeyCode u, KeyCode l, KeyCode d, KeyCode r, KeyCode j)
    {
        ismouse = false;
        up = u;
        left = l;
        down = d;
        right = r;
        jump = j;
    }
}
