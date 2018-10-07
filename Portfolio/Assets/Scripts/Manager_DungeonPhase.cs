using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Manager/Dungeon Phase", order = 1)]
public class Manager_DungeonPhase : ScriptableObject
{
    [SerializeField]
    private Variable_DungeonPhase explore;

    [SerializeField]
    private Variable_DungeonPhase battle;

    public Variable_DungeonPhase CurrentPhase { get; private set; }
    public Variable_DungeonPhase Phase_Explore { get { return explore; } }
    public Variable_DungeonPhase Phase_Battle { get { return battle; } }

    public void PhaseToBattle()
    {
        CurrentPhase = battle;
    }

    public void PhaseToExplore()
    {
        CurrentPhase = explore;
    }
}
