using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    public class IsPlayerLooking_Right_JB : ConditionTask
    {
        // condition to check if player is looking right

        private GameObject playerCam;
        protected override string OnInit()
        {
            playerCam = GameObject.FindGameObjectWithTag("MainCamera");
            if (playerCam == null)
            {
                return $"Jump Bug: Cannot find player camera.";
            }
            else
            {
                return null;
            }
        }

        protected override bool OnCheck()
        {
            // if player is looking right, return true
            if (playerCam.transform.rotation.y >= 0.6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}