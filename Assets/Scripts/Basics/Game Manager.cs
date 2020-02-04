using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public abstract class GM : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public abstract void win();
        public abstract void timeout();
        public abstract void announce(string s);
    }
}