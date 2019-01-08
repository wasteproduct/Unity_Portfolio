using UnityEngine;
using Battle;

public class Object_TomahawkChicken : MonoBehaviour
{
    [SerializeField]
    private Calculation_ApplyDamage damageApplier;
    [SerializeField]
    private Battle_TargetManager targetManager;
    [SerializeField]
    private Manager_BattlePhase phaseManager;

    private Vector3 rotation = new Vector3(0, 0, 12.8f);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetManager.FinalTargets[0].gameObject)
        {
            //GameObject explosion = Instantiate(effectExplosion, transform.position, transform.rotation);
            //explosion.GetComponent<EffectController>().PlayEffect();

            //eventSoundPlay.PlayedSound = soundExplosion;
            //eventSoundPlay.Run();

            damageApplier.ApplyDamage();
            phaseManager.EnterNextPhase();

            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(rotation);
    }
}
