using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_TreasureBox : Object_InteractorBase
{
    [SerializeField]
    private GameObject box;
    [SerializeField]
    private GameObject effectExplosion;
    [SerializeField]
    private CustomSound soundExplosion;
    [SerializeField]
    private Event_SoundPlay eventSoundPlay;

    private Animator animator;

    public override void Interact()
    {
        animator.SetBool("Open", true);
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(effectExplosion, transform.position, transform.rotation);
        explosion.GetComponent<EffectController>().PlayEffect();

        eventSoundPlay.PlayedSound = soundExplosion;
        eventSoundPlay.Run();
    }

    private void OnEnable()
    {
        
    }

    // Use this for initialization
    void Start()
    {
        animator = box.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
