using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwingBack : ActionTask {

		private float targetRotation;
		private float rotation;
		protected override string OnInit() {
			return null;
		}
		
		protected override void OnExecute() {
			targetRotation = -30;
		}

		protected override void OnUpdate() {
			agent.transform.Rotate(0, 0, -6 * Time.deltaTime);
			rotation += -6 * Time.deltaTime;
			if (rotation <= targetRotation)
			{
				EndAction(true);
			}
		}
	}
}