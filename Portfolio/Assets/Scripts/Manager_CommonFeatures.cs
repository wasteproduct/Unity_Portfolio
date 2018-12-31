using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Manager/Common", order = 1)]
public class Manager_CommonFeatures : ScriptableObject
{
    public readonly int invalidIndex = -1;
    public Manager_Layers layers;
    public Calculation_Turn rotationCalculator;
    public Variable_Bool interactingUI;
    public Variable_Bool cursorDisabled;

    public void Initialize()
    {
        interactingUI.flag = false;
        cursorDisabled.flag = false;
    }
}
