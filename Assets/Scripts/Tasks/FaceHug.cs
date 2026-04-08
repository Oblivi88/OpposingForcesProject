using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FaceHug : ActionTask {

		private float posX;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

        protected override void OnUpdate()
        {
			posX = -0.5f;
			agent.transform.position = new Vector3(posX, agent.transform.position.y, agent.transform.position.z);
        }
	}
}