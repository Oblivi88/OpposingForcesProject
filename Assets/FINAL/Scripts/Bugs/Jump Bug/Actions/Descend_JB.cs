using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Descend_JB : ActionTask {
		private float targetY;
		private float descentTime;
		private float descentSpeed;
		private Vector3 targetPos;
		private Vector3 currentPos;
		private Vector3 startPos;
		private GameObject playerCam;
		protected override string OnInit() {
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

		protected override void OnExecute() {
			targetY = 14.18f;
			descentTime = 0;
			descentSpeed = Random.Range(0.1f, 0.3f);
			startPos = agent.transform.position;
			targetPos = new Vector3(agent.transform.position.x, targetY, agent.transform.position.z);
            agent.transform.LookAt(playerCam.transform.position);
			agent.transform.rotation = Quaternion.Euler(0, agent.transform.eulerAngles.y, 0);
        }

		protected override void OnUpdate()
		{

			descentTime += Time.deltaTime * descentSpeed;
			currentPos = Vector3.Lerp(startPos, targetPos, descentTime);
			agent.transform.position = currentPos;

			if (descentTime >= 1)
			{
				EndAction(true);
			}
		}
	}
}