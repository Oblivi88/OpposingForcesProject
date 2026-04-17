using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class Death : ActionTask
    {
        public BBParameter<float> speedBBP;
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            if (speedBBP != null)
            {
                speedBBP.value = 1;
            }
            Object.Destroy(agent.gameObject);
            EndAction(true);
        }
    }
}