using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basics;
using UnityEngine.UI;

namespace twoplayer
{
    public class TP_GM : GM
    {
        public TP_Player p1, p2;
        public TP_VT victorytext;
        public TP_Timer timer;
        public TP_CM underling;

        public Text[] scoreboards;
        private int[] points = { 0 , 0 };
        private int boxesleft;

        private int announcetimer;

        public Button restart, menu;

        // Start is called before the first frame update
        void Start()
        {
            boxesleft = 12;
            updateboard();
            p1.activate();
            p2.activate();

            restart.gameObject.SetActive(false);
            menu.gameObject.SetActive(false);
            restart.onClick.AddListener(reloadStage);
            menu.onClick.AddListener(loadMenu);
        }

        public override void win()
        {
            end();
        }
        public override void timeout()
        {
            end();
        }
        public void end()
        {
            p1.deactivate();
            p2.deactivate();
            timer.stop();
            if(points[0] > points[1])
            {
                announce("Player 1 (Red) has won, with a score of " + points[0] + "!");
            }
            else if(points[1] > points[0])
            {
                announce("Player 2 (Blue) has won, with a score of " + points[1] + "!");
            }
            else
            {
                announce("We have a tie! Congratulations to both players!");
            }
            showEndButtons();
        }
        public override void announce(string s)
        {
            victorytext.sendMessage(s);
        }

        public void penalize(int i)
        {
            points[i]--;
            updateboard();
        }
        public void score(int i)
        {
            points[i]++;
            updateboard();
        }
        public void score(int i, Collider c)
        {
            if (underling.pickup(c))
            {
                points[i]++;
                updateboard();

                if (--boxesleft == 0)
                {
                    timer.lowerTo(16);
                }
            }
        }
        public void updateboard()
        {
            scoreboards[0].text = " Player 1  " + points[0];
            scoreboards[1].text = "Player 2   " + points[1];
        }

        public void reloadStage()
        {
            Overlord.changeStage(2);
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
    }
}