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

    private float maximumHP;

    public float CurrentHP { get; private set; }

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
        healthText.text = CurrentHP.ToString() + " / " + maximumHP.ToString();
    }

    public void Initialize()
    {
        maximumHP = 100.0f;
        CurrentHP = maximumHP;

        healthBar.maxValue = maximumHP;
        healthBar.minValue = 0.0f;
    }

    public void Heal(float healingAmount)
    {
        CurrentHP += healingAmount;

        if (CurrentHP > maximumHP) CurrentHP = maximumHP;
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
