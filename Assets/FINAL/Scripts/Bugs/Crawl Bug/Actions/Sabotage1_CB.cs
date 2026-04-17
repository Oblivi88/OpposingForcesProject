using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class Sabotage1_CB : ActionTask
    {

        private GameObject lightbulb1;
        private Lightbulb lightbulbScript1;
        private GameObject sparksObject1;
        private ParticleSystem sparks1;
        protected override string OnInit()
        {
            lightbulb1 = GameObject.FindGameObjectWithTag("LeftLight");
            lightbulbScript1 = lightbulb1.GetComponent<Lightbulb>();

            sparksObject1 = GameObject.FindGameObjectWithTag("LeftSpark");
            sparks1 = sparksObject1.GetComponent<ParticleSystem>();

            if (lightbulbScript1 == null || sparks1 == null)
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
            lightbulbScript1.dimSpeed *= 2;
            sparks1.Play();
            EndAction(true);
        }
    }
}