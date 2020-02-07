using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Overlord
{
    public static KeyBinds p1 = new KeyBinds(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.LeftShift);
    public static KeyBinds p2 = new KeyBinds(KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Space);

    public static void setKeyBinds(int controls1, int controls2)
    {
        switch (controls1)
        {
            case 0:
                p1 = new KeyBinds(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.LeftShift);
                break;
            case 1:
                p1 = new KeyBinds(KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Space);
                break;
            case 2:
                p1 = new KeyBinds(KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.RightShift);
                break;
            default:
                p1 = new KeyBinds();
                break;
        }
        switch (controls2)
        {
            case 0:
                p2 = new KeyBinds(KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.LeftShift);
                break;
            case 1:
                p2 = new KeyBinds(KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Space);
                break;
            case 2:
                p2 = new KeyBinds(KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow, KeyCode.RightShift);
                break;
            default:
                p2 = new KeyBinds();
                break;
        }
    }

    public static void changeStage(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void changeStage(int scene, int controls1, int controls2)
    {
        setKeyBinds(controls1, controls2);
        SceneManager.LoadScene(scene);
        
    }

}
