using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class FishManager : MonoBehaviour
    {
        //Does the Fishmanager care for the is3D bool or does the fish object?

        /// <summary>
        /// A reference to the instance with the correct settings
        /// </summary>
        public static FishManager instance;

        public Fish[] AvailableFish;

        // Start is called before the first frame update
        void Start()
        {
            //If every fishinghole has the exact same pool of fish
            if (!Approach.instance.UniqueFishingHoles)
            {
                //Disable any fishingholes or non-manager gameobject instances of a fishmanager
                if(gameObject.name != "FishingManager")
                {
                    enabled = false;
                    return;
                }

                //Make sure only one instance of this script exists
                if (instance == null)
                    instance = this;
                else if (instance != null && instance != this)
                    Destroy(gameObject);
            }

            else if (Approach.instance.UniqueFishingHoles && gameObject.name == "FishingManager")
            {
                enabled = false;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public Fish GetFish()
        {
            return AvailableFish[Random.Range(0, AvailableFish.Length)];
        }
    }
}
