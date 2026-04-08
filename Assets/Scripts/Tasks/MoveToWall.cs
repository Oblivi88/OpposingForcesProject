using NodeCanvas.Framework;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class MoveToWall : ActionTask
    {

        private NavMeshAgent navAgent;
        public BBParameter<float> xPos;
        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();

            if (navAgent == null)
            {
                return $"MoveToWall was unable to find navMeshAgent";
            }
            else
            {
                return null;
            }
        }

        protected override void OnExecute()
        {
            xPos.value = Random.Range(-4, 4);
            navAgent.SetDestination(new Vector3(xPos.value, 0.16f, 5f));
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