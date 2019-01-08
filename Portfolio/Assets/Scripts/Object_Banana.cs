using UnityEngine;

public class Object_Banana : MonoBehaviour
{
    [SerializeField]
    private Calculation_ApplyDamage damageApplier;
    [SerializeField]
    private Battle.Manager_BattlePhase phaseManager;
    [SerializeField]
    private GameObject effectExplosion;
    [SerializeField]
    private CustomSound soundExplosion;
    [SerializeField]
    private Event_SoundPlay eventSoundPlay;

    private float elapsedTime = 0.0f;

    private void Explode()
    {
        GameObject explosion = Instantiate(effectExplosion, transform.position, transform.rotation);
        explosion.GetComponent<EffectController>().PlayEffect();

        eventSoundPlay.PlayedSound = soundExplosion;
        eventSoundPlay.Run();

        damageApplier.ApplyDamage();
        phaseManager.EnterNextPhase();

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 2.0f) Explode();
    }
}
