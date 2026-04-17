using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsPlayerLooking_JB : ConditionTask {

		//check if player is looking left

		private GameObject playerCam;
		protected override string OnInit()
		{
			playerCam = GameObject.FindGameObjectWithTag("MainCamera");
			if (playerCam == null)
			{
				return $"Jump Bug: Cannot find player camera.";
			} else
			{
                return null;
            }
		}

		protected override bool OnCheck() {
			// if player is looking left, return true
			if (playerCam.transform.rotation.y <= -0.6)
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