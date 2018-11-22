using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debuff : MonoBehaviour
{
    public Debuff_Type DebuffType { get; private set; }
    public int RemainingCycles { get; private set; }
    public float ReductionRate { get; private set; }

    public void Initialize(Debuff_Data debuffData)
    {
        GetComponent<Image>().sprite = debuffData.UIImage;
        DebuffType = debuffData.DebuffType;
        RemainingCycles = debuffData.LastingCycles;
        ReductionRate = debuffData.ReductionRate;
    }
}
