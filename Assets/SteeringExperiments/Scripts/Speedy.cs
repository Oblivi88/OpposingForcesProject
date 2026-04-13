using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class Speedy : ActionTask {

        public BBParameter<float> timeSinceLastSampleBBP;
        public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<bool> isMoving;
        private float sampleRateInSeconds;
        private float wanderDistance = 1f;
        private float wanderRadius = 2f;

        private NavMeshAgent navAgent;

        protected override string OnInit() {
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

		protected override void OnExecute() {
            navAgent.speed = 2;
            sampleRateInSeconds = 1.5f;
            wanderDistance = 1.5f;
            wanderRadius = 1f;
            timeSinceLastSampleBBP.value = 0;
        }

        protected override void OnUpdate()
        {
            if (navAgent.velocity.magnitude > 0.1)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            if (isMoving.value == false)
            {
                timeSinceLastSampleBBP.value += Time.deltaTime;
            }
            
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