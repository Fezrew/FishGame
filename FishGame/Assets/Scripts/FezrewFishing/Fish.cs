using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FezrewFishing
{
    [CreateAssetMenu(fileName = "NewFish", menuName = "Fish", order = 1)]
    public class Fish : ScriptableObject
    {
        /// <summary>
        /// The name of the fish
        /// </summary>
        [Tooltip("The name of the fish")]
        public string Name;

        //Range-Catching Variables
        /// <summary>
        /// How large the fish is on the range catching bar
        /// The fish is easier to catch the higher this is
        /// </summary>
        [Tooltip("How large the fish is on the range catching bar")]
        public float FishRange;
        /// <summary>
        /// How quickly the fish moves in the range catching bar
        /// The fish is harder to catch the higher this is
        /// </summary>
        [Tooltip("How quickly the fish moves in the range catching bar")]
        public float FishSpeed;

        public void Start()
        {

        }
    }
}
