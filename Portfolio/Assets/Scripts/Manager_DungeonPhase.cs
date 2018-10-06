using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Manager/Dungeon Phase", order = 1)]
public class Manager_DungeonPhase : ScriptableObject
{
    public Variable_DungeonPhase explore;
    public Variable_DungeonPhase battle;

    public Variable_DungeonPhase CurrentPhase { get; private set; }

    public void PhaseToBattle()
    {
        CurrentPhase = battle;
    }

    public void PhaseToExplore()
    {
        CurrentPhase = explore;
    }
}
