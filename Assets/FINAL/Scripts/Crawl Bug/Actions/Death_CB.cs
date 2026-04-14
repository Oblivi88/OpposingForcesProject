using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Death_CB : ActionTask {

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			Debug.Log("i am dead blehhhhh");
			Object.Destroy(agent.gameObject);
		}
	}
}