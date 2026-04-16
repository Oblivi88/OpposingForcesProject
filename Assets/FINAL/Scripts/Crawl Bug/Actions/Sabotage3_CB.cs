using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class Sabotage3_CB : ActionTask
    {
        private GameObject lightbulb3;
        private Lightbulb lightbulbScript3;
        private GameObject sparksObject3;
        private ParticleSystem sparks3;
        protected override string OnInit()
        {
            lightbulb3 = GameObject.FindGameObjectWithTag("LeftLight");
            lightbulbScript3 = lightbulb3.GetComponent<Lightbulb>();

            sparksObject3 = GameObject.FindGameObjectWithTag("LeftSpark");
            sparks3 = sparksObject3.GetComponent<ParticleSystem>();

            if (lightbulbScript3 == null || sparks3 == null)
            {
                return $"Unable to locate script.";
            }
            else
            {
                return null;
            }

        }

        protected override void OnExecute()
        {
            lightbulbScript3.dimSpeed *= 2;
            sparks3.Play();
            EndAction(true);
        }
    }
}