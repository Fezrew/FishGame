using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class Approach : MonoBehaviour
    {
        /// <summary>
        /// A reference to the instance with the correct settings
        /// </summary>
        public static Approach instance;

        /// <summary>
        /// Determines whether to use 3D models or 2D sprites for the fish
        /// </summary>
        [Tooltip("Determines whether to use 3D models or 2D sprites for the fish")]
        public bool is3D;
        /// <summary>
        /// Can the fish be seen in the water?
        /// </summary>
        [Tooltip("Can the fish be seen in the water?")]
        public bool FishVisible;

        [Space]
        /// <summary>
        /// Does the fishing minigame use fishing rods with differing values/models?
        /// </summary>
        [Tooltip("Does the fishing minigame use fishing rods with differing values/models?")]
        public bool UniqueFishingRods;
        /// <summary>
        /// Do different fish bite more often/only bite when using specific bait?
        /// </summary>
        [Tooltip("Do different fish bite more often/only bite when using specific bait?")]
        public bool HasBait;
        /// <summary>
        /// Are there multiple places to fish that have different possible fish?
        /// </summary>
        [Tooltip("Are there multiple places to fish that have different possible fish? (REMEMBER: Attach Fishmanager to each FishingHole object if you want this)")]
        public bool UniqueFishingHoles;

        // Start is called before the first frame update
        void Awake()
        {
            //Make sure only one instance of this script exists
            //We do this for the same reason as the FishingManager
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
