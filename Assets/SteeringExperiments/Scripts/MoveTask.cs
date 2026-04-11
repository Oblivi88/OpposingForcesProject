using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {
	public class MoveTask : ActionTask {

		private int movementChoice;
		private NavMeshAgent navAgent;

		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
            if (navAgent == null)
            {
                return $"unable to find navMeshAgent";
            }
            else
            {
                return null;
            }
        }

		protected override void OnExecute() {
			//movementChoice = Random.Range(1, 3);
			movementChoice = 1;
			if (movementChoice == 1)
			{
				navAgent.SetDestination(new Vector3(Random.Range(1, 9), agent.transform.position.y, 7));
			}
		}

		protected override void OnUpdate() {
			
		}
	}
}