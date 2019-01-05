using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Event/Use Item", order = 1)]
public class Event_UseItem : CustomEvent
{
    public Character_InDungeonPortrait TargetCharacter { get; set; }
}
