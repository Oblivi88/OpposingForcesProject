using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    public class ChangeColour_CB : ActionTask
    {

        private NavMeshAgent navAgent;
        private MeshRenderer meshRenderer;
        public BBParameter<Material> defaultMaterial;
        public BBParameter<Material> telegraphedMaterial;

        private float telegraphLevel;
        private float telegraphSpeed = 0.25f;
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

            meshRenderer.material.Lerp(defaultMaterial.value, telegraphedMaterial.value, telegraphLevel);

            if (telegraphLevel >= 1)
            {
                EndAction(true);
            }
        }
    }
}