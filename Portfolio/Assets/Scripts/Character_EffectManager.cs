using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_EffectManager : MonoBehaviour
{
    public GameObject hitEffect;
    public GameObject[] actionEffects;

    public void PlayActionEffect(Battle.Battle_Action executedAction)
    {
        for (int i = 0; i < actionEffects.Length; i++)
        {
            if (executedAction.ActionState == actionEffects[i].GetComponent<EffectController>().actionState)
            {
                actionEffects[i].gameObject.SetActive(true);

                actionEffects[i].GetComponent<EffectController>().PlayEffect();

                return;
            }
        }
    }

    public void PlayHitEffect()
    {
        if (hitEffect == null) return;

        hitEffect.gameObject.SetActive(true);

        hitEffect.GetComponent<EffectController>().PlayEffect();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
