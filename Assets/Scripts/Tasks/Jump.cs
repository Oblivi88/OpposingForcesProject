using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Jump : ActionTask {

		private float posX;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute()
		{
            posX = -4.863f;
        }

		protected override void OnUpdate()
		{
            posX += 0.02f;
            agent.transform.position = new Vector3(posX, agent.transform.position.y, agent.transform.position.z);
			if (posX >= -0.5f)
			{
				EndAction(true);
			}
        }
	}
}