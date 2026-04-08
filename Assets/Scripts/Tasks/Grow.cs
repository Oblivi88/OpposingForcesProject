using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Grow : ActionTask {

		private float scaleY;
		private float scaleZ;
		protected override string OnInit() {
			return null;
		}
		protected override void OnExecute() {
			scaleY = agent.transform.localScale.y;
			scaleZ = agent.transform.localScale.z;
		}

		protected override void OnUpdate() {
			scaleY += 0.0001f;
			scaleZ += 0.0001f;
			agent.transform.localScale = new Vector3(0.26638f, scaleY, scaleZ);
			if (scaleY >= 0.4f)
			{
				EndAction(true);
			}
		}
	}
}