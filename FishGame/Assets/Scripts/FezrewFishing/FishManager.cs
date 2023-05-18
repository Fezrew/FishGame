using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class FishManager : MonoBehaviour
    {
        //TODO: Make a dictionary/List?? holding all the fish that can be caught
        //Does the Fishmanager care for the is3D bool or does the fish object?
        
        /// <summary>
        /// A reference to the instance with the correct settings
        /// </summary>
        public static FishManager instance;

        // Start is called before the first frame update
        void Start()
        {
            //Make sure only one instance of this script exists
            //FishingManager holds some settings for the minigame's design and more than one manager may mess with a user's fishing settings
            if (instance == null)
                instance = this;
            else if (instance != null && instance != this)
                Destroy(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
