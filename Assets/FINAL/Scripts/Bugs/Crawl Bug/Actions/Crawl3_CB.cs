using NodeCanvas.Framework;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class Crawl3_CB : ActionTask
    {
        // uses some of wanderTask from previous assignment
        // third crawl type, speed and stop
        public BBParameter<float> timeSinceLastSampleBBP;
        public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<float> speedBBP;
        private bool isMoving;
        private float sampleRateInSeconds;
        private float wanderDistance = 1f;
        private float wanderRadius = 2f;

        private NavMeshAgent navAgent;

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
            // at spawn, set values
            speedBBP.value = 2f;
            sampleRateInSeconds = 1.5f;
            wanderDistance = 1.5f;
            wanderRadius = 0.6f;
            timeSinceLastSampleBBP.value = 0;
        }

        protected override void OnUpdate()
        {
            // set isMoving bool
            navAgent.speed = speedBBP.value;
            if (navAgent.velocity.magnitude > 0.1)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            // if it is not moving, increase time since last sample
            if (isMoving == false)
            {
                timeSinceLastSampleBBP.value += Time.deltaTime;
            }
            // calculate a random point forward every [sampleRateInSeconds] seconds.
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
            // if bug reaches close enough to wall, immediately move to wall
            if (navAgent.transform.position.z >= wall.transform.position.z - 0.7f)
            {
                navAgent.SetDestination(new Vector3(agent.transform.position.x, agent.transform.position.y, wall.transform.position.z));
            }
            // if bug reaches wall, end task
            if (navAgent.transform.position.z >= wall.transform.position.z)
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