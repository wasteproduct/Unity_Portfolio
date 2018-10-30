using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Character/State List", order = 1)]
public class Character_StateList : ScriptableObject
{
    public Character_State idleExploration;
    public Character_State runExploration;
    public Character_State idleBattle;
    public Character_State runBattle;
}
