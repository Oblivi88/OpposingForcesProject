using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    public class ChangeColour_CB : ActionTask
    {

        private NavMeshAgent navAgent;
        private MeshRenderer meshRenderer;

        private float telegraphLevel;
        private float telegraphSpeed = 0.1f;
        protected override string OnInit()
        {
            navAgent = agent.GetComponent<NavMeshAgent>();
            meshRenderer = agent.GetComponent<MeshRenderer>();
            if (navAgent == null)
            {
                return $"Crawl Bug: Unable to find navMeshAgent.";
            }
            else
            {
                return null;
            }
        }

        protected override void OnUpdate()
        {
            telegraphLevel += Time.deltaTime * telegraphSpeed;
            if (telegraphLevel > 1)
            {
                telegraphLevel = 1;
            }

            meshRenderer.material.color = Color.Lerp(Color.black, Color.darkRed, telegraphLevel);

            if (meshRenderer.material.color == Color.darkRed)
            {
                EndAction(true);
            }
        }
    }
}