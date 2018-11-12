using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapDataSet;
using UnityEngine.UI;
using Skill;

public class Character_InBattle : MonoBehaviour
{
    public Calculation_Move moveController;
    public Character_State idleBattle;
    public Character_State runBattle;
    public Character_State damaged;
    public Character_State dead;
    public GameObject battleStatus;
    public Skill_Base skill1;

    public Slider healthBar;
    public Text healthText;

    private Quaternion targetRotation;
    private float elapsedTime;
    private int nextTileIndex;
    private Quaternion startingRotation;
    private Character_StateManager stateManager;

    // temporary
    public int AttackRange { get; private set; }
    //public MeshRenderer meshRenderer;
    public int MovableDistance { get; private set; }
    public float CurrentHP { get; private set; }
    public float AttackDamage { get; private set; }
    private float maximumHP;

    public Map_Data MapData { get; private set; }
    public bool Dead { get; private set; }
    public bool TurnFinished { get; private set; }
    public int StandingTileX { get; private set; }
    public int StandingTileZ { get; private set; }
    public bool Arrived { get; private set; }
    public bool StartAction { get; private set; }
    public bool ActionFinished()
    {
        TurnFinished = true;
        return true;
    }

    public void SetTurnFinished(bool flag) { TurnFinished = flag; }

    public void FinishBattle()
    {
        battleStatus.SetActive(false);
    }

    public void StartBattle()
    {
        battleStatus.SetActive(true);
        healthBar.value = CurrentHP;
    }

    public void Damage(float attackDamage)
    {
        CurrentHP -= attackDamage;

        if (CurrentHP <= 0.0f)
        {
            Dead = true;
            stateManager.SetState(dead);
        }
        else stateManager.SetState(damaged);
    }

    public void SetState(Character_State newState)
    {
        stateManager.SetState(newState);
    }

    public void SetTrack()
    {
        elapsedTime = 0.0f;
        nextTileIndex = 1;
        startingRotation = gameObject.transform.rotation;
        Arrived = false;

        moveController.SetTrack(MapData);
    }

    public void SetTargetRotation(Vector3 targetPosition)
    {
        StartAction = false;

        Vector3 forward = targetPosition - gameObject.transform.position;
        targetRotation = Quaternion.LookRotation(forward);
    }

    public void HeadToTarget()
    {
        if (StartAction == true) return;

        elapsedTime += Time.deltaTime;

        float lerpTime = elapsedTime / moveController.ElapsedTimeLimit;

        gameObject.transform.rotation = Quaternion.Lerp(startingRotation, targetRotation, lerpTime);

        if (lerpTime >= 1.0f) StartAction = true;
    }

    public void Move()
    {
        if (Arrived == true) return;

        elapsedTime += Time.deltaTime;

        gameObject.transform.position = moveController.LerpPosition(nextTileIndex, elapsedTime);
        gameObject.transform.rotation = moveController.LerpRotation(nextTileIndex, elapsedTime, startingRotation);

        if (elapsedTime >= moveController.ElapsedTimeLimit)
        {
            elapsedTime = 0.0f;
            nextTileIndex++;
            startingRotation = gameObject.transform.rotation;

            if (nextTileIndex >= moveController.Track.Count)
            {
                stateManager.SetState(idleBattle);
                Arrived = true;
            }
        }
    }

    // temporary
    public void HighlightAsTarget(bool flag)
    {
        //meshRenderer.material.color = (flag == true) ? Color.red : Color.white;
    }

    public void Initialize(Map_Data mapData, bool enemyCharacter)
    {
        MapData = mapData;

        Dead = false;
        TurnFinished = false;

        StandingTileX = (int)(gameObject.transform.position.x + .5f);
        StandingTileZ = (int)(gameObject.transform.position.z + .5f);

        startingRotation = gameObject.transform.rotation;
        stateManager = GetComponent<Character_StateManager>();

        if (enemyCharacter == true) gameObject.layer = LayerMask.NameToLayer("Enemy");

        // temporary
        maximumHP = 100.0f;
        CurrentHP = maximumHP;
        AttackRange = 3;
        MovableDistance = 3;
        AttackDamage = 50.0f;
        if (enemyCharacter == true)
        {
            AttackRange = 1;
            MovableDistance = 2;
            AttackDamage = 25.0f;
        }
        healthBar.maxValue = maximumHP;
        healthBar.minValue = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.StandingTileX = (int)(this.gameObject.transform.position.x + .5f);
        this.StandingTileZ = (int)(this.gameObject.transform.position.z + .5f);

        healthBar.value = CurrentHP;
        healthText.text = CurrentHP.ToString() + " / " + maximumHP.ToString();
    }
}
