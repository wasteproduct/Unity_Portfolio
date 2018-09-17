using System.Collections.Generic;
using UnityEngine;

public class CustomEvent : ScriptableObject
{
    private List<CustomEventListener> listeners = new List<CustomEventListener>();

    public void Run()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].Run();
        }
    }

    public void RegisterListener(CustomEventListener listener) { if (listeners.Contains(listener) == false) listeners.Add(listener); }
    public void UnregisterListener(CustomEventListener listener) { if (listeners.Contains(listener) == true) listeners.Remove(listener); }
}
