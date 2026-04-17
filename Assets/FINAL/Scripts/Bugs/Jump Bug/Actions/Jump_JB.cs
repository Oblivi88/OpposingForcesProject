using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    public class Jump_JB : ActionTask
    {
        // once descent has finished and player looks in the appropriate direction, jump at player
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
                return $"Jump Bug: unable to find camera.";
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
            // swing towards player
            if (rotation > targetRotation)
            {
                agent.transform.Rotate((rotateSpeedBBP.value * -20) * Time.deltaTime, 0, 0);
                rotation -= (rotateSpeedBBP.value * 20) * Time.deltaTime;
            }
            // when swing is finished, launch towards player
            if (rotation <= targetRotation)
            {
                agent.transform.position += agent.transform.forward * (rotateSpeedBBP.value * 2) * Time.deltaTime;
            }
            // if it reaches player camera, set the HP to 10, end task
            if (agent.transform.position.x >= playerCam.transform.position.x - 0.7f)
            {
                clickDetection.bugHP = 10;
                EndAction(true);
            }
        }
    }
}