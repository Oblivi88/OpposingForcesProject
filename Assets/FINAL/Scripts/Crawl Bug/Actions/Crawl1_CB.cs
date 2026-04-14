using NodeCanvas.Framework;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class Crawl1_CB : ActionTask
    {
        private NavMeshAgent navAgent;
        public BBParameter<Vector3> targetPosBBP;
        public BBParameter<Transform> wallPosBBP;

        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
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
            targetPosBBP.value = new Vector3(Random.Range(1, 9), agent.transform.position.y, wallPosBBP.value.position.z);

            navAgent.SetDestination(targetPosBBP.value);
        }
        protected override void OnUpdate()
        {
            if (navAgent.remainingDistance <= 0.1 && !navAgent.pathPending)
            {
                EndAction(true);
            }
        }
    }
}
