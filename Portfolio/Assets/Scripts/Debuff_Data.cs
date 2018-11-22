using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Debuff/Data", order = 1)]
public class Debuff_Data : ScriptableObject
{
    [SerializeField]
    private Debuff_Type debuffType;
    [SerializeField]
    private int lastingCycles;
    [SerializeField]
    private Sprite uIImage;
    [SerializeField]
    private float reductionRate;

    public Debuff_Type DebuffType { get { return debuffType; } }
    public int LastingCycles { get { return lastingCycles; } }
    public Sprite UIImage { get { return uIImage; } }
    public float ReductionRate { get { return reductionRate; } }
}
