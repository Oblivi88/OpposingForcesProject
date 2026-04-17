using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions
{
    // second movement type, zigzag
    // pieces used from WanderTask from previous assignment
    public class Crawl2_CB : ActionTask
    {
        // values to define movement
        public BBParameter<float> timeSinceLastSampleBBP;
        public BBParameter<Vector3> targetPositionBBP;
        public BBParameter<float> speedBBP;
        private float sampleRateInSeconds;
        private float wanderDistance;
        private float wanderRadius;

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
            // on spawn, set values
            sampleRateInSeconds = 0.5f;
            wanderDistance = 1f;
            wanderRadius = 0.5f;
            timeSinceLastSampleBBP.value = 0;
        }
        protected override void OnUpdate()
        {
            // take a new sample every [sampleRateInSeconds] seconds
            navAgent.speed = speedBBP.value;
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
            // if bug reaches close enough to wall, immediately go to the wall
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
        // calculate positions when zigzagging
        private Vector3 CalculateTargetPosition()
        {
            Vector3 circleCenter = agent.transform.position + agent.transform.forward * wanderDistance;
            Vector3 randomPoint = Random.insideUnitSphere.normalized * wanderRadius;

            Vector3 destination = circleCenter + randomPoint;

            return destination;
        }
    }
}