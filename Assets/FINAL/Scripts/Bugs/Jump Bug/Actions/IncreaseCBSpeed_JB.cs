using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class IncreaseCBSpeed_JB : ActionTask {

        // if a jump bug is on the players face, momentarily increase the speed of which the crawl bugs move.
        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			// find every active crawl bug in the scene
            GameObject[] crawlBugs = GameObject.FindGameObjectsWithTag("CrawlBug");
			// for every crawl bug currently in the scene, access the blackboard, and set the speed variable to 3.
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