using NodeCanvas.Framework;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class GoBehindWall : ActionTask
    {

        private NavMeshAgent navAgent;
        private float xPos;
        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();

            if (navAgent == null)
            {
                return $"GoBehindWall was unable to find navMeshAgent";
            }
            else
            {
                return null;
            }
        }

        protected override void OnExecute()
        {
            xPos = agent.transform.position.x;
            navAgent.SetDestination(new Vector3(xPos, 0.16f, 7f));
        }

        protected override void OnUpdate()
        {
            if (navAgent.remainingDistance == 0 && !navAgent.pathPending)
            {
                EndAction(true);
            }
        }
    }
}