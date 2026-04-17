using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class Sabotage2_CB : ActionTask
    {
        private GameObject lightbulb2;
        private Lightbulb lightbulbScript2;
        private GameObject sparksObject2;
        private ParticleSystem sparks2;
        protected override string OnInit()
        {
            lightbulb2 = GameObject.FindGameObjectWithTag("MainLight");
            lightbulbScript2 = lightbulb2.GetComponent<Lightbulb>();

            sparksObject2 = GameObject.FindGameObjectWithTag("MainSpark");
            sparks2 = sparksObject2.GetComponent<ParticleSystem>();

            if (lightbulbScript2 == null || sparks2 == null)
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
            lightbulbScript2.dimSpeed *= 2;
            sparks2.Play();
            EndAction(true);
        }
    }
}