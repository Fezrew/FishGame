using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FezrewFishing
{
    public class RangeCatch : Catch
    {
        /// <summary>
        /// A reference to the instance with the correct settings
        /// </summary>
        public static new RangeCatch instance;

        // Start is called before the first frame update
        new void Awake()
        {
            //Make sure only one instance of this script exists
            //Particularly important as a version of this class gets created in the start of Catch
            if (instance == null)
                instance = this;
            else if (instance != null && instance != this)
                Destroy(this.gameObject);
        }

        // Update is called once per frame
        public override void Update()
        {
            if (FishingManager.instance.CurrentPhase == FishingManager.fishingPhase.Catch)
            {
                //Move the catch range upwards if it hasn't hit the top
                if (Input.GetKey(KeyCode.Space))
                {
                    if (rangePosition + (CatchRange / 2) < CatchBarMax)
                        rangePosition += (Time.deltaTime * RangeSpeed);
                }
                //Move the range downwards if it hasn't hit the bottom
                else if (rangePosition - (CatchRange / 2) > 0)
                {
                    rangePosition -= (Time.deltaTime * RangeSpeed);
                }

                //TO DO: Make a fish class to be referenced to
                //Move the fish up or down
                //if (swimUpwards && fishPosition + (FishingManager.instance.fish.FishRange / 2) < CatchBarMax)
                //{
                //    fishPosition += (Time.deltaTime * FishingManager.instance.fish.FishSpeed);
                //}
                //else if (!swimUpwards && fishPosition - (FishingManager.instance.fish.FishRange / 2) > CatchBarMax)
                //{
                //    fishPosition -= (Time.deltaTime * FishingManager.instance.fish.FishSpeed);
                //}

                //If the catch range overlaps with the fish range, add progress
                //First check if the top end of the fish range overlaps with the catch range, then do the same for the bottom of the fish range
                //if (rangePosition - (CatchRange / 2) < fishPosition + (FishingManager.instance.fish.FishRange / 2) &&
                //    rangePosition + (CatchRange / 2) > fishPosition + (FishingManager.instance.fish.FishRange) ||
                //    rangePosition - (CatchRange / 2) < fishPosition - (FishingManager.instance.fish.FishRange / 2) &&
                //    rangePosition + (CatchRange / 2) > fishPosition - (FishingManager.instance.fish.FishRange))
                //    //Increase the progress meter as there is overlap
                //    catchProgress += Time.deltaTime;
                //else
                //    //Decrease the progress meter as there is no overlap
                //    catchProgress -= Time.deltaTime;

                catchProgress = Mathf.Clamp(catchProgress, 0, ProgressRequired);

                //Check if the progress required has been met
                if (catchProgress >= ProgressRequired)
                {
                    SucceedCatch();
                    return;
                }

                //After enough time has passed, make the fish randomly select another direction to move in
                if (decisionTimer >= DecisionTime)
                    DecideDirection();

                decisionTimer += Time.deltaTime;
            }
        }

        public override void BeginCatch()
        {
            Debug.Log("CATCH THE FISH!!");
            rangePosition = CatchRange / 2;
            fishPosition = CatchBarMax / 2;
        }

        /// <summary>
        /// Randomly selects which direction the fish will start moving in
        /// </summary>
        void DecideDirection()
        {
            int decision = Random.Range(0, 2);
            if (decision == 0)
                swimUpwards = false;
            else
                swimUpwards = true;

            decisionTimer = 0;
        }
    }
}
