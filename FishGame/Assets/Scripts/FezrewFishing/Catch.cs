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


        public void Start()
        {
            //Make sure only one instance of this script exists
            //We do this for the same reason as the FishingManager
            if (instance == null)
                instance = this;
            else if (instance != null && instance != this)
                Destroy(this.gameObject);
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
            FishingManager.instance.FinishFishing();
        }
    }
}
