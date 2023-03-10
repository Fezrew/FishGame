using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    /// <summary>
    /// Determines the phases of the fishing game
    /// </summary>
    public class FishingManager : MonoBehaviour
    {
        public static FishingManager instance;

        /// <summary>
        /// Allows the user to add unique rods/baits/locations
        /// </summary>
        public static bool HasApproach = false;

        public void Start()
        {
            //Make sure only one instance of this script exists
            //FishingManager holds some settings for the minigame's design and more than manager may mess with a user's fishing settings
            if (instance == null)
                instance = this;
            else if (instance != null && instance != this)
                Destroy(this.gameObject);
        }
    }
}
