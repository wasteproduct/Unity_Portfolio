using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player_Animation : MonoBehaviour
{
    protected Animator animator;

    private float idleActionTime = 0.0f;

    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        idleActionTime += Time.deltaTime;
    }
}
