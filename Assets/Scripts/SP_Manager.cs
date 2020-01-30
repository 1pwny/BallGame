using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Basics;

public class SP_Manager : Manager
{
    public SP_Player player;
    public SP_Cam cam;
    public SP_VT victorytext;
    public SP_Timer timer;
    public Text scoreboard;

    private int collectables;


    // Start is called before the first frame update
    void Start()
    {
        collectables = 0;
        // player.setManager(this);
        player.activate();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void win()
    {
        player.deactivate();
        victorytext.sendVictoryMessage(timer.getTime());
    }

    public override void timeout()
    {
        player.deactivate();
        if (collectables == 12)
            victorytext.sendVictoryMessage(timer.getTime());
        else
            victorytext.sendDefeatMessage("You lost with only " + collectables + " / 12!");
    }

    public void updateboard()
    {
        scoreboard.text = "Score: " + collectables + " / 12";
    }

    public void score()
    {
        collectables++;
        updateboard();

        if(collectables == 12)
        {
            win();
        }
    }
}
