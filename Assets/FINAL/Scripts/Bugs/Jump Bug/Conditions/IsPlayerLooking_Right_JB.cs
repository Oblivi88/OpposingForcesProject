using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    public class IsPlayerLooking_Right_JB : ConditionTask
    {

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

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck()
        {
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