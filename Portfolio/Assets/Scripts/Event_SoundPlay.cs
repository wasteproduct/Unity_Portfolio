using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Event/Sound Play", order = 1)]
public class Event_SoundPlay : CustomEvent
{
    public CustomSound PlayedSound { get; set; }
}
