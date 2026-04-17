using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class HasBeenSquashed : ConditionTask
    {
        private ClickDetection clickDetection;
        protected override string OnInit()
        {
            clickDetection = agent.GetComponent<ClickDetection>();
            if (clickDetection == null)
            {
                return $"Unable to find clickDetection script.";
            }
            else
            {
                return null;
            }
        }

        protected override bool OnCheck()
        {
            return (clickDetection.bugHP <= 0);
        }
    }
}