using UnityEngine;
using UnityEngine.UI;

public class Character_ConditionManager : MonoBehaviour
{
    // temporary
    [SerializeField]
    private float maximumHP;
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Sprite portraitImage;

    public float MaximumHP { get { return maximumHP; } }
    public float CurrentHP { get; private set; }
    public Sprite PortraitImage { get { return portraitImage; } }

    public void DamageByBoobyTrap()
    {
        CurrentHP -= MaximumHP / 3.0f;
    }

    public void ReduceHealth(float attackDamage)
    {
        CurrentHP -= attackDamage;
    }

    public void StartBattle()
    {
        healthBar.value = CurrentHP;
    }

    public void CustomUpdate()
    {
        healthBar.value = (int)CurrentHP;
        healthText.text = healthBar.value.ToString() + " / " + MaximumHP.ToString();
    }

    public void Initialize()
    {
        CurrentHP = MaximumHP;

        healthBar.maxValue = MaximumHP;
        healthBar.minValue = 0.0f;
    }

    public void Heal(float healingAmount)
    {
        CurrentHP += healingAmount;

        if (CurrentHP > MaximumHP) CurrentHP = MaximumHP;
    }
}
