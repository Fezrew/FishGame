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
        /// <summary>
        /// A reference to the instance with the correct settings
        /// </summary>
        public static FishingManager instance;

        enum fishingPhase
        {
            Approach,
            Bite,
            Catch
        }
        fishingPhase currentPhase;

        /// <summary>
        /// Allows the user to add unique rods/baits/locations
        /// </summary>
        public static bool HasApproach = false;

        /// <summary>
        /// Unlike the Bite script's isFishing, this boolean is just to avoid interactions between scripts while the player is fishing
        /// We don't want the player moving around or starting to fish a second time while they are fishing.
        /// </summary>
        [HideInInspector]
        public static bool fishing;

        public void Start()
        {
            //Make sure only one instance of this script exists
            //FishingManager holds some settings for the minigame's design and more than manager may mess with a user's fishing settings
            if (instance == null)
                instance = this;
            else if (instance != null && instance != this)
                Destroy(this.gameObject);

            currentPhase = fishingPhase.Approach;
        }

        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0) && !fishing)
            {
                StartFishing();
            }
        }

        /// <summary>
        /// Checks any variables to the fishing scenario caused by the approach phase, then begins bite phase
        /// </summary>
        public void StartFishing()
        {
            //Prevent anything other than fishing
            fishing = true;

            if(HasApproach)
            {

                NextPhase();
            }
            else
            {

                NextPhase();
            }

            Debug.Log("You cast the lure out!");
        }

        public void NextPhase()
        {
            switch(currentPhase)
            {
                case fishingPhase.Approach:
                    currentPhase = fishingPhase.Bite;
                    Bite.instance.StartPhase();
                    break;

                case fishingPhase.Bite:
                    currentPhase = fishingPhase.Catch;
                    Catch.instance.BeginCatch();
                    break;
            }
        }

        public void FinishFishing()
        {
            fishing = false;
            currentPhase = fishingPhase.Approach;
        }
    }
}
