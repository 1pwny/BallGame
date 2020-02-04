using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Basics
{
    public abstract class PickupManager : MonoBehaviour
    {
        protected HashSet<GameObject> collectibles;

        // Start is called before the first frame update
        void Start()
        {
            collectibles = new HashSet<GameObject>(GameObject.FindGameObjectsWithTag("Collectable"));
            initCollectibles();
        }

        protected abstract void initCollectibles();

        // Update is called once per frame
        void LateUpdate()
        {
            if (total == collected)
                overlord.win();
        }

        //register pickup
        public bool pickup(GameObject go)
        {
            if(collectibles.Contains(go))
            {
                go.SetActive(false);
                collectibles.Remove(go);
                return true;
            }

            return false;
        }
    }
}