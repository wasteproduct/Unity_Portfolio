using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Calculation/Move", order = 1)]
public class Calculation_Move : ScriptableObject
{
    public bool moving = false;

    private readonly float elapsedTimeLimit = .2f;

    public float ElapsedTimeLimit { get { return elapsedTimeLimit; } }
}
