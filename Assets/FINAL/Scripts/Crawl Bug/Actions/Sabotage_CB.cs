using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Sabotage_CB : ActionTask {

		public BBParameter<Lightbulb> lightbulbScriptBBP;
		public BBParameter<ParticleSystem> sparks;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			lightbulbScriptBBP.value.dimSpeed += 0.02f;
			sparks.value.Play();
			EndAction(true);
		}
	}
}