using UnityEngine;

public abstract class Interactor_Base : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Event_Click clickEvent;
    [SerializeField]
    protected Interactor_ReactionBase[] interactorReaction;

    public abstract void Interact();
    public abstract void CallReaction();
}
