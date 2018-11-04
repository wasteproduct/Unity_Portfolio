using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miscellaneous_UIRotation : MonoBehaviour
{
    public Variable_Quaternion rotationBattleStatus;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotationBattleStatus.value;
    }
}
