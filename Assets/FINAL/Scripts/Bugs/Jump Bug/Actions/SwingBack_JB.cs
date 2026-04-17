using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SwingBack_JB : ActionTask
	{
        private float targetRotationX;
        private float rotation;
        public BBParameter<float> rotationSpeedBBP;
        protected override string OnInit()
		{
            return null;
		}

		protected override void OnExecute()
		{
            targetRotationX = 18;
        }

		protected override void OnUpdate()
		{
            agent.transform.Rotate(rotationSpeedBBP.value * Time.deltaTime, 0, 0);
            rotation += rotationSpeedBBP.value * Time.deltaTime;
            if (rotation >= targetRotationX)
            {
                EndAction(true);
            }
        }
	}
}