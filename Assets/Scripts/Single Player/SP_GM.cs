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
        private static SP_GM gameManager = new SP_GM();
        public static SP_GM getManager()
        {
            return gameManager;
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

        public SP_Player player;
        public SP_Cam cam;
        public SP_VT victorytext;
        public SP_Timer timer;
        public SP_CM underling;

        public Text scoreboard;
        private int score, max;



        // Start is called before the first frame update
        void Start()
        {
            score = 0;
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
            scoreboard.text = "Score: " + score + " / " + underling.;
        }
        public void score(Collider c)
        {
            updateboard();

            if (collectables == 12)
            {
                win();
            }
        }
    }
}