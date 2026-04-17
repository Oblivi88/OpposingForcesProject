using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class StickToFace_JB : ActionTask {

		// latch onto the players face, by setting it to be a child of the players camera. the bug will stay on screen
		// no matter where player looks
		// this repeats infinitely until bug is killed
		private GameObject playerCam;
		protected override string OnInit() {

			playerCam = GameObject.FindGameObjectWithTag("MainCamera");

			if (playerCam == null)
			{
				return $"Jump Bug: unable to find camera.";
			}
			else
			{
				return null;
			}
		}

		protected override void OnExecute() {
			agent.transform.SetParent(playerCam.transform, true);
			EndAction(true);
		}
	}
}