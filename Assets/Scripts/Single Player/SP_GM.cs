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
        private int points, max, penalties;

        private int announcetimer;

        public Button restart, menu;

        // Start is called before the first frame update
        void Start()
        {
            points = 0;
            penalties = 0;
            updateboard();
            player.activate();

            restart.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
            restart.onClick.AddListener(reloadStage);
            menu.onClick.AddListener(loadMenu);
        }

        public void reloadStage()
        {
            Overlord.changeStage(1);
        }
        public void loadMenu()
        {
            Overlord.changeStage(0);
        }
        void showEndButtons()
        {
            restart.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
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
            showEndButtons();
        }
        public override void timeout()
        {
            player.deactivate();
            if (points == 12)
                victorytext.sendVictoryMessage(timer.getTime());
            else
                victorytext.sendDefeatMessage("You lost with only " + (points-penalties) + " / " + max + "!");
            showEndButtons();
        }
        public override void announce(string s)
        {
            victorytext.sendMessage(s);
        }

        public void penalize()
        {
            penalties++;
            updateboard();
        }

        public void setMax(int i)
        {
            max = i;
        }
        public void updateboard()
        {
            scoreboard.text = "Score: " + (points-penalties) + " / " + max;
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