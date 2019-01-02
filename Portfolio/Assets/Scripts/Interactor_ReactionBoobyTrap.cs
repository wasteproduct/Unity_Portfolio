using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Interactor/Booby Trap", order = 1)]
public class Interactor_ReactionBoobyTrap : Interactor_ReactionBase
{
    [SerializeField]
    private GameObject effectExplosion;
    [SerializeField]
    private CustomSound soundExplosion;
    [SerializeField]
    private Event_SoundPlay eventSoundPlay;
    [SerializeField]
    private Event_BoobyTrap eventBoobyTrap;

    public override void InteractorReacts(Object_InteractorBase interactor)
    {
        Transform interactorTransform = interactor.gameObject.transform;

        GameObject explosion = Instantiate(effectExplosion, interactorTransform.position, interactorTransform.rotation);
        explosion.GetComponent<EffectController>().PlayEffect();

        eventSoundPlay.PlayedSound = soundExplosion;
        eventSoundPlay.Run();

        eventBoobyTrap.Run();

        Destroy(interactor.gameObject);
    }
}
