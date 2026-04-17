using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions
{

    public class ChangeColour_CB : ActionTask
    {
        // changes colour when it reaches wall (black-red)
        private NavMeshAgent navAgent;
        private MeshRenderer meshRenderer;
        // materials to lerp between
        public BBParameter<Material> defaultMaterial;
        public BBParameter<Material> telegraphedMaterial;
        // changing speed
        private float telegraphLevel;
        private float telegraphSpeed = 0.25f;
        protected override string OnInit()
        {
            // on spawn, get navAgent and meshRenderer
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
            // lerp between black and red materials, end action when complete.
            telegraphLevel += Time.deltaTime * telegraphSpeed;
            meshRenderer.material.Lerp(defaultMaterial.value, telegraphedMaterial.value, telegraphLevel);
            if (telegraphLevel >= 1)
            {
                telegraphLevel = 1;
                EndAction(true);
            }
        }
    }
}