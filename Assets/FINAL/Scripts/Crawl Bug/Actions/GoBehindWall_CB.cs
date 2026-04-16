using NodeCanvas.Framework;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class GoBehindWall_CB : ActionTask
    {

        private NavMeshAgent navAgent;
        private float xPos;
        private GameObject wall;
        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
            wall = GameObject.FindGameObjectWithTag("MainWall");

            if (navAgent == null)
            {
                return $"Crawl Bug: Unable to find navMeshAgent.";
            }
            else
            {
                return null;
            }
        }

        protected override void OnExecute()
        {
            xPos = agent.transform.position.x;
            navAgent.SetDestination(new Vector3(xPos, 0.16f, wall.transform.position.z + 2));
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