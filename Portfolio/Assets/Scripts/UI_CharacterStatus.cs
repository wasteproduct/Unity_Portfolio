using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterStatus : MonoBehaviour
{
    [SerializeField]
    private Text textStrength;
    [SerializeField]
    private Text textAgility;
    [SerializeField]
    private Text textIntelligence;

    private const string strength = "Strength : ";
    private const string agility = "Agility : ";
    private const string intelligence = "Intelligence : ";

    public void ClearValues()
    {
        textStrength.text = strength;
        textAgility.text = agility;
        textIntelligence.text = intelligence;
    }

    public void UpdateStatusValue(Character.Character_Base selectedCharacter)
    {
        textStrength.text = strength + selectedCharacter.Strength.ToString();
        textAgility.text = agility + selectedCharacter.Agility.ToString();
        textIntelligence.text = intelligence + selectedCharacter.Intelligence.ToString();
    }
}
