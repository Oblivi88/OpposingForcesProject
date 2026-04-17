using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class IncreaseCBSpeed_JB : ActionTask {

        
        protected override string OnInit() {
			return null;
		}

		
		protected override void OnExecute() {
            GameObject[] crawlBugs = GameObject.FindGameObjectsWithTag("CrawlBug");
			foreach (GameObject crawlBug in crawlBugs)
			{
				Blackboard crawlBugBB = crawlBug.GetComponent<Blackboard>();
				if (crawlBugBB != null)
				{
					crawlBugBB.SetVariableValue("SpeedBBP", 3f);
				}
			}
			EndAction(true);
		}

		protected override void OnUpdate() {
			
		}
	}
}