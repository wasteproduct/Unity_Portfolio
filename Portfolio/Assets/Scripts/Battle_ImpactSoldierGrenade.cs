using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    [CreateAssetMenu(fileName = "", menuName = "Attack Action Impact/Soldier Grenade", order = 1)]
    public class Battle_ImpactSoldierGrenade : Battle_ImpactBase
    {
        public Battle_TurnController turnController;
        public Battle_TargetManager targetManager;

        [SerializeField]
        private GameObject banana;

        public override void Run()
        {
            Transform soldierTransform = turnController.CurrentTurnCharacter.gameObject.transform;

            Vector3 targetPosition = targetManager.FinalTargets[0].gameObject.transform.position + Vector3.up;

            Vector3 force = targetPosition - soldierTransform.position;

            GameObject grenade = Instantiate(banana, soldierTransform.position + Vector3.up, soldierTransform.rotation);

            grenade.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}
