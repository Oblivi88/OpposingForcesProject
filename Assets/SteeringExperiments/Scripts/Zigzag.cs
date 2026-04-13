using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    // a combination of the WanderTask and NavigationTask scripts from class, and some of my own needed additions
    public class Zigzag : ActionTask
    {
        public BBParameter<float> timeSinceLastSampleBBP;
        public BBParameter<Vector3> targetPositionBBP;
        private float sampleRateInSeconds;
        private float wanderDistance = 1f;
        private float wanderRadius = 2f;

        private NavMeshAgent navAgent;

        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();

            if (navAgent == null)
            {
                return $"Unable to find agent";
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

            if (navAgent.transform.position.z >= 7)
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