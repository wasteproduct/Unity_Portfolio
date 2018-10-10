using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Calculation/Move", order = 1)]
public class Calculation_Move : ScriptableObject
{
    public Vector3 LerpPosition(Vector3 startPosition, Vector3 targetPosition, float elapsedTime)
    {
        return Vector3.Lerp(startPosition, targetPosition, elapsedTime / .2f);
    }
}
