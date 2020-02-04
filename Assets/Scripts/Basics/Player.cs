using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Basics
{
    public abstract class Player : MonoBehaviour
    {
        public int speed;
        public Rigidbody rb;
        
        private bool active;
        

        // Start is called before the first frame update
        protected void Start()
        {
            rb = GetComponent<Rigidbody>();
            //init();
        }
        protected abstract void init();

        // Update is called once per frame
        protected void FixedUpdate()
        {
            if (active)
            {
                float horiz = Input.GetAxis("Horizontal");
                float vert = Input.GetAxis("Vertical");

                Vector3 move = new Vector3(horiz, 0.0f, vert);

                rb.AddForce(move * speed);
            }
        }

        protected abstract void OnTriggerEnter(Collider other);

        public void deactivate()
        {
            active = false;
        }
        public void activate()
        {
            active = true;
        }
    }
}