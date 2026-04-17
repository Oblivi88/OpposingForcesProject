using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    public class Jump_Right_JB : ActionTask
    {
        // exact same as Jump_JB script, but for the bugs spawned on the right side
        private float targetRotation;
        private float rotation;
        public BBParameter<float> rotateSpeedBBP;
        private GameObject playerCam;
        private ClickDetection clickDetection;
        protected override string OnInit()
        {
            clickDetection = agent.GetComponent<ClickDetection>();
            playerCam = GameObject.FindGameObjectWithTag("MainCamera");
            if (playerCam == null)
            {
                return $"Jump Bug (right side): unable to find camera.";
            }
            else
            {
                return null;
            }
        }

        protected override void OnExecute()
        {
            rotation = 0;
            targetRotation = -18;
        }

        protected override void OnUpdate()
        {
            if (rotation > targetRotation)
            {
                agent.transform.Rotate((rotateSpeedBBP.value * -20) * Time.deltaTime, 0, 0);
                rotation -= (rotateSpeedBBP.value * 20) * Time.deltaTime;
            }
            if (rotation <= targetRotation)
            {
                agent.transform.position += agent.transform.forward * (rotateSpeedBBP.value * 2) * Time.deltaTime;
            }

            if (agent.transform.position.x <= playerCam.transform.position.x + 0.7f) // the other direction
            {
                clickDetection.bugHP = 10;
                EndAction(true);
            }
        }
    }
}