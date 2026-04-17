using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class StickToFace_JB : ActionTask {

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