using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Banana : MonoBehaviour
{
    public Calculation_ApplyDamage damageApplier;
    public Battle.Manager_BattlePhase phaseManager;
    public GameObject effectExplosion;
    public CustomSound soundExplosion;
    public Event_SoundPlay eventSoundPlay;

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
