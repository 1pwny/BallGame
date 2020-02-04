using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public abstract class PickupManager : MonoBehaviour
    {
        public HashSet<GameObject> collectibles;
        public GameObject[] cols;

        // Start is called before the first frame update
        void Start()
        {
            //collectibles = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag("Collectable"));
            collectibles = new HashSet<GameObject>(cols);
            initCollectibles();
        }

        protected abstract void initCollectibles();

        //register pickup
        public bool pickup(Collider go)
        {
            if(collectibles.Contains(go.gameObject))
            {
                go.gameObject.SetActive(false);
                collectibles.Remove(go.gameObject);
                return true;
            }

            return false;
        }
    }
}