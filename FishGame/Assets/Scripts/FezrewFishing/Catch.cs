using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class Catch : MonoBehaviour
    {
        public static Catch instance;

        public enum catchType
        {
            AutoCatch,
            MashCatch,
            QuicktimeCatch
        };
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
    }
}
