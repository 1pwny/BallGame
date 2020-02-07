using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BC : MonoBehaviour
{
    public Button me;
    public Text text;
    public DataController controller;

    private bool selected;

    public int player, num;

    // Start is called before the first frame update
    void Start()
    {
        if (player > -1)
        {
            controller.buttons[player,num] = this;
            setListener();
        }
    }

    public void select()
    {
        if (!selected)
        {
            text.text += " (Selected)";
            selected = true;
        }
    }
    public void unselect()
    {
        if (selected)
        {
            text.text = text.text.Substring(0, text.text.Length - 11);
            selected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enable()
    {
        me.enabled = true;
    }
    public void disable()
    {
        me.enabled = false;
    }

    public void choosethis()
    {
        controller.setPC(player, num);
    }
    public void setListener()
    {
        me.onClick.AddListener(choosethis);
    }
    public void listen(UnityAction call)
    {
        me.onClick.AddListener(call);
    }
}
