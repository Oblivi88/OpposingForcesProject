using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class Sabotage_CB : ActionTask {

		public BBParameter<Lightbulb> lightbulbScriptBBP;
		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			lightbulbScriptBBP.value.dimSpeed += 0.02f;
			EndAction(true);
		}
	}
}