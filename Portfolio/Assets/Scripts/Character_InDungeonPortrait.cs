using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_InDungeonPortrait : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Image selectedFrame;
    [SerializeField]
    private Event_UseItem eventUseItem;

    public Character_ConditionManager CharacterCondition { get; private set; }

    public void HighlightPortrait(bool flag)
    {
        gameObject.GetComponent<Button>().interactable = flag;

        selectedFrame.gameObject.SetActive(flag);
    }

    public void Initialize(GameObject correspondingCharacter)
    {
        CharacterCondition = correspondingCharacter.gameObject.GetComponent<Character_ConditionManager>();
        GetComponent<Image>().sprite = CharacterCondition.PortraitImage;

        healthBar.maxValue = CharacterCondition.MaximumHP;
        healthBar.minValue = 0.0f;
        healthBar.value = CharacterCondition.CurrentHP;
    }

    public void UseItem()
    {
        eventUseItem.TargetCharacter = this;
        eventUseItem.Run();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = CharacterCondition.CurrentHP;
    }
}
