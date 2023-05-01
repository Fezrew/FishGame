using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class Catch : MonoBehaviour
    {
        /// <summary>
        /// A reference to the instance with the correct settings
        /// </summary>
        public static Catch instance;

        #region Catch Variables
        /// <summary>
        /// What is the minigame you want to play after you've begun catch phase
        /// </summary>
        public enum catchType
        {
            /// <summary>
            /// Catch phase ends automatically and the player catches the fish
            /// </summary>
            AutoCatch,
            /// <summary>
            /// The player has to press an input multiple times in order to catch the fish
            /// </summary>
            MashCatch,
            /// <summary>
            /// The player has to press a series of inputs in the correct order in order to catch the fish
            /// </summary>
            QuicktimeCatch
        };
        /// <summary>
        /// This variable creates the drop-down selection in Unity for easy use in-editor
        /// </summary>
        [Tooltip("The minigame that begins once the player reaches catch phase")]
        public catchType CatchType;
        /// <summary>
        /// How close the player is to catching the fish
        /// This should only be changed in this script
        /// </summary>
        private float catchProgress;
        /// <summary>
        /// Allows external scripts to read the catchProgress
        /// Mostly to allow UI displays of the current progress
        /// </summary>
        [Tooltip("How close the player is to catching the fish (Read-only)")]
        public float CatchProgress => catchProgress;
        /// <summary>
        /// The amount of progress the player must reach before the fish is caught
        /// FOR RANGE CATCHING THIS IS THE NUMBER OF SECONDS YOU NEED TO SPEND CATCHING IT
        /// </summary>
        [Tooltip("The amount of progress the player must reach before the fish is caught")]
        public float ProgressRequired;
        #endregion

        #region Range Catching Variables
        /// <summary>
        /// The highest value the fishRange or catchRange can get before being stopped
        /// </summary>
        [Tooltip("The highest value the fishRange or catchRange can get before being stopped")]
        public float CatchBarMax;

        /// <summary>
        /// The value range of which you must keep the fishes value within in order to gain catch progress
        /// </summary>
        [Tooltip("The value range of which you must keep the fishes value within in order to gain catch progress")]
        public float CatchRange;
        /// <summary>
        /// How fast the catch range moves in the catch bar
        /// </summary>
        [Tooltip("How fast the catch range moves in the catch bar")]
        [Range(1, 10)]
        public float RangeSpeed;
        /// <summary>
        /// the position of the centre of the player's catch range
        /// </summary>
        float rangePosition;
        /// <summary>
        /// The position of the centre of the fish
        /// </summary>
        float fishPosition;

        //Read-only variables for the position values
        public float FishPos => fishPosition;
        public float RangePos => rangePosition;

        /// <summary>
        /// The time before the fish decides their movement direction
        /// </summary>
        [Tooltip("The time before the fish decides their movement direction")]
        public float DecisionTime = 1;
        /// <summary>
        /// Once this equals DecisionTime, the fish decides the next direction
        /// </summary>
        float decisionTimer;
        /// <summary>
        /// Is the fish swimming upwards?
        /// </summary>
        bool swimUpwards;
        #endregion

        public void Start()
        {
            //Make sure only one instance of this script exists
            //We do this for the same reason as the FishingManager
            if (instance == null)
                instance = this;
            else if (instance != null && instance != this)
                Destroy(this.gameObject);
        }

        //TODO: Create derived catch classes for each Catch Type
        public void Update()
        {
            
        }

        /// <summary>
        /// Catch phase begins when this function is called.
        /// Determines how the phase plays based on the settings
        /// </summary>
        public void BeginCatch()
        {
            switch(CatchType)
            {
                case catchType.AutoCatch:
                    SucceedCatch();
                    break;

                case catchType.MashCatch:
                    break;

                case catchType.QuicktimeCatch:
                    break;
            }
        }

        void FailCatch()
        {
            Debug.Log("You dun didn't do it");
            FishingManager.instance.FinishFishing();
        }

        void SucceedCatch()
        {
            Debug.Log("You dun did it");
            FishingManager.instance.FinishCatchEvent.Invoke();
            FishingManager.instance.FinishFishing();
        }
    }
}
