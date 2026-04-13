using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Descend : ActionTask {

		private Vector3 currentPos;
		private Vector3 targetPos;
		private float descentTime;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			descentTime = 0;
			currentPos = agent.transform.position;
			targetPos = new Vector3(agent.transform.position.x, agent.transform.position.y - 3, agent.transform.position.z);
		}

		protected override void OnUpdate() {
			descentTime += Time.deltaTime * 0.1f;
            agent.transform.position = Vector3.Lerp(currentPos, targetPos, descentTime);

			if (agent.transform.position == targetPos)
			{
				EndAction(true);
			}
        }
	}
}