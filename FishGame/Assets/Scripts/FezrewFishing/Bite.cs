using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class Bite : MonoBehaviour
    {
        /// <summary>
        /// A reference to the instance with the correct settings
        /// </summary>
        public static Bite instance;

        /// <summary>
        /// The longest time it can take for a fish to bite
        /// </summary>
        [Tooltip("The longest time it can take for a fish to bite")]
        public float MaxFishTime;
        /// <summary>
        /// The shortest time it can take for a fish to bite
        /// </summary>
        [Tooltip("The shortest time it can take for a fish to bite")]
        public float MinFishTime;

        /// <summary>
        /// The time the player has to press the reel input within in order to begin the catch phase
        /// </summary>
        [Tooltip("The time the player has to press the reel input within in order to begin the catch phase")]
        public float ReelWindow;

        /// <summary>
        /// The length of time the player has been in the bite phase for
        /// </summary>
        float fishTimer;
        /// <summary>
        /// The time spent within the reeling window
        /// </summary>
        float reelTimer;

        //Booleans used to determine if the timers should be increasing
        bool isFishing;
        bool isReeling;

        public void Start()
        {
            //Make sure only one instance of this script exists
            //We do this for the same reason as the FishingManager
            if (instance == null)
                instance = this;
            else if (instance != null && instance != this)
                Destroy(this.gameObject);
        }

        public void Update()
        {
            if (isFishing)
                fishTimer += Time.deltaTime;
            else if (isReeling)
                reelTimer += Time.deltaTime;
        }

        public void StartPhase()
        {
            fishTimer = 0;
            reelTimer = 0;
        }

        public void ReelBegin()
        {
            Debug.Log("A fish took the bait!");
        }

        public void ReelFailed()
        {
            Debug.Log("The fish got away...");
        }
    }
}
