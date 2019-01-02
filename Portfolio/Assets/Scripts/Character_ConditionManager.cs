using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_ConditionManager : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Sprite portraitImage;

    public float MaximumHP { get; private set; }
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
        healthBar.value = CurrentHP;
        healthText.text = CurrentHP.ToString() + " / " + MaximumHP.ToString();
    }

    public void Initialize()
    {
        MaximumHP = 100.0f;
        CurrentHP = MaximumHP;

        healthBar.maxValue = MaximumHP;
        healthBar.minValue = 0.0f;
    }

    public void Heal(float healingAmount)
    {
        CurrentHP += healingAmount;

        if (CurrentHP > MaximumHP) CurrentHP = MaximumHP;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
