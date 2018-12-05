using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    public bool loop;
    public float playTimeLength;
    public Character_State actionState;
    public bool destroyed;

    private ParticleSystem particleComponent = null;

    public void PlayEffect()
    {
        if (particleComponent == null) particleComponent = GetComponent<ParticleSystem>();

        StartCoroutine(ParticleUpdate());
    }

    private IEnumerator ParticleUpdate()
    {
        particleComponent.Play();

        // 지속성 이펙트
        if (loop == true) yield return new WaitForSeconds(playTimeLength);
        // 단발성 이펙트
        else
        {
            while (true)
            {
                if (particleComponent.isStopped == true) break;

                yield return null;
            }
        }

        gameObject.SetActive(false);

        if (destroyed == true) Destroy(gameObject);
    }
}
