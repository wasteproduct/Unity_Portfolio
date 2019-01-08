using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Attack Action Impact/Big Bully Tomahawk", order = 1)]
    public class Battle_ImpactBigBullyTomahawk : Battle_ImpactBase
    {
        public Battle_TurnController turnController;
        public Battle_TargetManager targetManager;

        [SerializeField]
        private GameObject chicken;

        public override void Run()
        {
            Transform bullyTransform = turnController.CurrentTurnCharacter.gameObject.transform;

            Vector3 targetPosition = targetManager.FinalTargets[0].gameObject.transform.position + Vector3.up;

            GameObject tomahawk = Instantiate(chicken, bullyTransform.position + Vector3.up, bullyTransform.rotation);

            Vector3 force = targetPosition - tomahawk.transform.position;
            force *= 2.0f;

            tomahawk.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}
