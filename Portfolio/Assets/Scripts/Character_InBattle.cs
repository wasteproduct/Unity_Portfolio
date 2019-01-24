using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapDataSet;
using Battle;

public class Character_InBattle : MonoBehaviour
{
    public Calculation_Move moveController;
    public Character_State idleBattle;
    public Character_State runBattle;
    public Character_State damaged;
    public Character_State dead;
    public GameObject battleStatus;
    public Battle_Action actionAttack;
    public Battle_Action[] actionSkills;

    public GameObject conditionPanel;
    public GameObject debuffPrefab;

    private Quaternion targetRotation;
    private float elapsedTime;
    private int nextTileIndex;
    private Quaternion startingRotation;
    private Character_StateManager stateManager;
    private Character_ConditionManager conditionManager;

    // temporary
    public int MovableDistance { get; private set; }

    public Map_Data MapData { get; private set; }
    public bool Dead { get; private set; }
    public bool TurnFinished { get; private set; }
    public int StandingTileX { get; private set; }
    public int StandingTileZ { get; private set; }
    public bool Arrived { get; private set; }
    public bool StartAction { get; private set; }
    public List<Debuff> AppliedDebuffs { get; private set; }
    public Character_EffectManager EffectManager { get; private set; }
    public bool ActionFinished()
    {
        TurnFinished = true;
        return true;
    }

    public void SetTurnFinished(bool flag) { TurnFinished = flag; }

    public void ApplyDebuff(Debuff_Data appliedDebuffData)
    {
        GameObject newDebuff = Instantiate(debuffPrefab, conditionPanel.transform);
        newDebuff.GetComponent<Debuff>().Initialize(appliedDebuffData);

        AppliedDebuffs.Add(newDebuff.GetComponent<Debuff>());
    }

    public void FinishBattle()
    {
        battleStatus.SetActive(false);
    }

    public void StartBattle()
    {
        battleStatus.SetActive(true);
        conditionManager.StartBattle();
    }

    public void Damage(float attackDamage)
    {
        conditionManager.ReduceHealth(attackDamage);

        if (conditionManager.CurrentHP <= 0.0f)
        {
            Dead = true;
            stateManager.SetState(dead);
            GetComponent<Character_QuestHandler>().UpdateQuestProgression();
        }
        else stateManager.SetState(damaged);

        EffectManager.PlayHitEffect();
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

    public void Initialize(Map_Data mapData, bool enemyCharacter)
    {
        MapData = mapData;

        Dead = false;
        TurnFinished = false;

        StandingTileX = (int)(gameObject.transform.position.x + .5f);
        StandingTileZ = (int)(gameObject.transform.position.z + .5f);

        startingRotation = gameObject.transform.rotation;

        AppliedDebuffs = new List<Debuff>();

        // temporary
        conditionManager.Initialize();
        MovableDistance = 3;
        if (enemyCharacter == true) MovableDistance = 2;
    }

    private void Awake()
    {
        stateManager = GetComponent<Character_StateManager>();
        EffectManager = GetComponent<Character_EffectManager>();
        conditionManager = GetComponent<Character_ConditionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StandingTileX = (int)(gameObject.transform.position.x + .5f);
        StandingTileZ = (int)(gameObject.transform.position.z + .5f);

        conditionManager.CustomUpdate();
    }
}
