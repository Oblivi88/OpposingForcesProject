using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions {

	public class HasBeenSquashed_CB : ConditionTask {

		private ClickDetection_CB clickDetection;
		protected override string OnInit(){
			clickDetection = agent.GetComponent<ClickDetection_CB>();
			if (clickDetection == null)
			{
				return $"Crawl Bug: Unable to find clickDetection script.";
			} else
			{
				return null;
			}
		}

		protected override bool OnCheck() {
            return clickDetection.isSquashed;
		}
	}
}