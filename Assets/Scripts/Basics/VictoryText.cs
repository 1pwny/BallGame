using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Basics
{
    public abstract class VictoryText : MonoBehaviour
    {
        public Text myself;

        private bool won;

        // Start is called before the first frame update
        void Start()
        {
            won = false;
            myself.text = "";
        }

        public virtual void sendMessage(string mes)
        {
            if(!won)
                myself.text = mes;
        }

        public virtual void sendDefeatMessage(string mes)
        {
            myself.text = mes;
        }

        public virtual void sendVictoryMessage()
        {
            won = true;
            myself.text = "Congratulations! You won!";
        }

    }
}