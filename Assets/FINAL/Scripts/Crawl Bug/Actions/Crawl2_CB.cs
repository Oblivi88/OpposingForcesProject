using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    // a combination of the WanderTask and NavigationTask scripts from class, and some of my own needed additions
    public class Crawl2_CB : ActionTask
    {
        public BBParameter<float> timeSinceLastSampleBBP;
        public BBParameter<Vector3> targetPositionBBP;
        private float sampleRateInSeconds;
        private float wanderDistance = 1f;
        private float wanderRadius = 0.6f;

        private NavMeshAgent navAgent;

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
            sampleRateInSeconds = 0.5f;
            wanderDistance = 1f;
            wanderRadius = 1f;
            timeSinceLastSampleBBP.value = 0;
        }
        protected override void OnUpdate()
        {
            timeSinceLastSampleBBP.value += Time.deltaTime;
            if (timeSinceLastSampleBBP.value > sampleRateInSeconds)
            {
                timeSinceLastSampleBBP.value = 0;
            }
            if (timeSinceLastSampleBBP.value == 0)
            {
                Vector3 destination = CalculateTargetPosition();

                if (NavMesh.SamplePosition(destination, out NavMeshHit hitInfo, wanderDistance + wanderRadius, NavMesh.AllAreas))
                {
                    targetPositionBBP.value = hitInfo.position;
                    navAgent.SetDestination(targetPositionBBP.value);
                }
            }
            if (navAgent.transform.position.z >= wallPosBBP.value.position.z - 0.7f)
            {
                navAgent.SetDestination(new Vector3(agent.transform.position.x, agent.transform.position.y, wallPosBBP.value.position.z));
            }
            if (navAgent.transform.position.z >= wallPosBBP.value.position.z)
            {
                EndAction(true);
            }
        }
        private Vector3 CalculateTargetPosition()
        {
            Vector3 circleCenter = agent.transform.position + agent.transform.forward * wanderDistance;
            Vector3 randomPoint = Random.insideUnitSphere.normalized * wanderRadius;

            Vector3 destination = circleCenter + randomPoint;

            return destination;
        }
    }
}