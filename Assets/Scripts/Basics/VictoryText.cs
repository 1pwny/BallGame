using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Basics
{
    public abstract class VictoryText : MonoBehaviour
    {
        public Text myself;

        // Start is called before the first frame update
        void Start()
        {
            myself.text = "";
        }

        public virtual void sendDefeatMessage(string mes)
        {
            myself.text = mes;
        }

        public virtual void sendVictoryMessage()
        {
            myself.text = "Congratulations! You won!";
        }

    }
}