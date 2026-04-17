using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class Death : ActionTask
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            Object.Destroy(agent.gameObject);
            EndAction(true);
        }
    }
}