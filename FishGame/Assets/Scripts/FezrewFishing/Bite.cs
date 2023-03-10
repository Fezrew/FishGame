using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class Bite : MonoBehaviour
    {
        public static Bite instance;

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
