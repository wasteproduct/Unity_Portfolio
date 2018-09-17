using UnityEngine;
using UnityEngine.Events;

public class CustomEventListener : MonoBehaviour
{
    public CustomEvent registeredEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        registeredEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        registeredEvent.UnregisterListener(this);
    }

    public void Run()
    {
        response.Invoke();
    }
}
