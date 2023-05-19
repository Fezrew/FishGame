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
            if (!Approach.instance.UniqueFishingHoles)
            {
                //Make sure only one instance of this script exists
                //FishingManager holds some settings for the minigame's design and more than one manager may mess with a user's fishing settings
                if (instance == null)
                    instance = this;
                else if (instance != null && instance != this)
                    Destroy(this.gameObject);
            }
            else
                this.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
