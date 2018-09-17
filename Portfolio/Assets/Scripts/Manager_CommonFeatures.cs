using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Manager/Common", order = 1)]
public class Manager_CommonFeatures : ScriptableObject
{
    public readonly int invalidIndex = -1;
    public Manager_Layers layers;
    public Calculation_Turn rotationCalculator;
}
