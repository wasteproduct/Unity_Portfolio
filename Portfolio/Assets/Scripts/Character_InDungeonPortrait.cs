using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_InDungeonPortrait : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;

    private Character_ConditionManager characterCondition;

    public void Initialize(GameObject correspondingCharacter)
    {
        characterCondition = correspondingCharacter.gameObject.GetComponent<Character_ConditionManager>();
        GetComponent<Image>().sprite = characterCondition.PortraitImage;

        healthBar.maxValue = characterCondition.MaximumHP;
        healthBar.minValue = 0.0f;
        healthBar.value = characterCondition.CurrentHP;
    }

    public void UseItem()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = characterCondition.CurrentHP;
    }
}
