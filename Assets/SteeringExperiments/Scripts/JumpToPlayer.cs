using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class JumpToPlayer : ActionTask
    {

        private float targetRotation;
        private float rotation;
        private float currentPos;
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            rotation = 0;
            targetRotation = 30;
            currentPos = agent.transform.position.x;
        }

        protected override void OnUpdate()
        {
            if (rotation < targetRotation)
            {
                agent.transform.Rotate(0, 0, 120 * Time.deltaTime);
                rotation += 120 * Time.deltaTime;
            }
            if (rotation >= targetRotation)
            {
                currentPos += 12 * Time.deltaTime;
                agent.transform.position = new Vector3(currentPos, agent.transform.position.y, agent.transform.position.z);
            }

            if (currentPos >= 3)
            {
                EndAction(true);
            }
        }
    }
}