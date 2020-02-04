using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Basics;

namespace singleplayer
{
    public class SP_GM : GM
    {

        //getting the game manager
        /*
        public static SP_GM manager;
        public static SP_GM getManager()
        {
            return manager;
        }
        public void register(MonoBehaviour thing)
        {
            if (thing is SP_Player)
            {
                player = (SP_Player)thing;
            }
            if (thing is SP_Cam)
            {
                cam = (SP_Cam)thing;
            }
            if (thing is SP_VT)
            {
                victorytext = (SP_VT)thing;
            }
            if (thing is SP_Timer)
            {
                timer = (SP_Timer)thing;
            }
            if (thing is SP_CM)
            {
                underling = (SP_CM)thing;
                max = underling.left();
            }
        }
        // */

        public SP_Player player;
        public SP_Cam cam;
        public SP_VT victorytext;
        public SP_Timer timer;
        public SP_CM underling;

        public Text scoreboard;
        private int points, max;

        private int announcetimer;

        // Start is called before the first frame update
        void Start()
        {
            points = 0;
            updateboard();
            player.activate();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public override void win()
        {
            player.deactivate();
            timer.stop();
            victorytext.sendVictoryMessage(timer.getTime());
        }
        public override void timeout()
        {
            player.deactivate();
            if (points == 12)
                victorytext.sendVictoryMessage(timer.getTime());
            else
                victorytext.sendDefeatMessage("You lost with only " + points + " / " + max + "!");
        }
        public override void announce(string s)
        {
            victorytext.sendMessage(s);
        }

        public void setMax(int i)
        {
            max = i;
        }
        public void updateboard()
        {
            scoreboard.text = "Score: " + points + " / " + max;
        }
        public void score(Collider c)
        {
            if (underling.pickup(c))
            {
                points++;
                updateboard();

                if (points == max)
                {
                    win();
                }
            }
        }
    }
}