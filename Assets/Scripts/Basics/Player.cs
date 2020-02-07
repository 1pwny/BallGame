using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Basics
{
    public abstract class Player : MonoBehaviour
    {
        protected int speed = 500, jumpforce = 200;
        public Rigidbody rb;
        public KeyBinds kbs;

        private bool active;
        

        // Start is called before the first frame update
        protected void Start()
        {
            //Overlord.setKeyBinds(0, 1);
            rb = GetComponent<Rigidbody>();
            init();
        }
        protected abstract void init();

        // Update is called once per frame
        protected void FixedUpdate()
        {
            if (!active)
                return;

            if(kbs.ismouse)
            {
                float h = speed / 100 * Input.GetAxis("Mouse X");
                float v = speed / 100 * Input.GetAxis("Mouse Y");
                rb.AddForce(new Vector3(h, 0, v));

                /*
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();

                if (floor.GetComponent<Collider>().Raycast(ray, out hit, 100))
                {
                    Vector3 goal = ray.GetPoint(100);
                    Vector3 direction = goal - transform.position;

                    print(goal);
                    print(direction);

                    direction.z -= 50;
                    direction.y = 0;

                    rb.AddForce(direction.normalized * speed / 100);
                    
                }
                // */

                if (Input.GetMouseButton(0) && transform.position.y == 0.5)
                {
                    rb.AddForce(Vector3.up * jumpforce);
                }

                return;
            }

            
            if (Input.GetKey(kbs.left))
            {
                rb.AddForce((-1 * speed * Time.deltaTime), 0, 0);
            }
            if (Input.GetKey(kbs.up))
            {
                rb.AddForce(0, 0, (1 * speed * Time.deltaTime));
            }
            if (Input.GetKey(kbs.right))
            {
                rb.AddForce((1 * speed * Time.deltaTime), 0, 0);
            }
            if (Input.GetKey(kbs.down))
            {
                rb.AddForce(0, 0, (-1 * speed * Time.deltaTime));
            }
            if (Input.GetKey(kbs.jump) && transform.position.y == 0.5)
            {
                rb.AddForce(Vector3.up * jumpforce);
            }  
            // */

            /*
            float horiz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(horiz, 0.0f, vert);

            rb.AddForce(move * speed);
            // */
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