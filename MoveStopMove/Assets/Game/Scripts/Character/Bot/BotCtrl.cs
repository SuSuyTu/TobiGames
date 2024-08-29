using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotCtrl : CharacterCtrl
{
    [Header("Bot Ctrl")]
    [SerializeField] protected NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent => navMeshAgent;
    [SerializeField] protected GameObject botCircleTargeted;
    public GameObject BotCircleTargeted => botCircleTargeted;
    [SerializeField] protected BotStateManager botStateManager;
    public BotStateManager BotStateManager => botStateManager;
    // [SerializeField] protected Transform botIndicatorPoint;
    // public Transform BotIndicatorPoint => botIndicatorPoint;
    public BotIndicator botIndicator;
    public Constants.BotName botName;

    public Vector3 destination;
    public bool IsDestination => Vector3.Distance(this.transform.position, destination + (this.transform.position.y - destination.y) * Vector3.up) < 0.1f;
   
    protected override void Reset() 
    {
        base.Reset();
        LoadBotNavMeshAgent();
        LoadBotCircleTargeted();
        LoadBotStateManager();
    }

    protected virtual void LoadBotNavMeshAgent()
    {
        if (this.navMeshAgent != null) return;
        this.navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        Debug.LogWarning(transform.name + ": LoadBotNavMeshAgent", gameObject);
    }

    protected virtual void LoadBotCircleTargeted()
    {
        if (this.botCircleTargeted != null) return;
        this.botCircleTargeted = transform.Find("BotCircleTargeted").gameObject;
        Debug.LogWarning(transform.name + ": LoadBotCircleTargeted", gameObject);
    }

    protected virtual void LoadBotStateManager()
    {
        if (this.botStateManager != null) return;
        this.botStateManager = GetComponentInChildren<BotStateManager>();
        Debug.LogWarning(transform.name + ": LoadBotStateManager", gameObject);
    }

    protected override void LoadAttackPosition()
    {
        if (this.characterAttackPosition != null) return;
        this.characterAttackPosition = transform.Find("BotAttackPosition");
        Debug.LogWarning(transform.name + ": LoadAttackPosition", gameObject);
    }

    public virtual void RotateTo(Vector3 target)
    {
        Vector3 tmpPos = target - transform.position;
        tmpPos.y = 0;
        transform.forward = tmpPos.normalized;
    }

    // protected virtual void OnDisable() 
    // {
    //     navMeshAgent.enabled = false;
    // }

    // protected virtual void OnEnable() 
    // {
    //     navMeshAgent.enabled = true;
    // }

    // public override void StopMove()
    // {
    //     base.StopMove();
    //     navMeshAgent.ResetPath();// = false;
    // }

    public virtual void MoveTo(Vector3 destination)
    {
        this.destination = destination;
        //this.NavMeshAgent.enabled = true;
        this.NavMeshAgent.SetDestination(destination);
    }

    public virtual void SetUpIndicator() 
    {
        //wayPointIndicator = SimplePool.Spawn<Indicator>(PoolType.Indicator, transform.position, Quaternion.identity);
        botIndicator = IndicatorSpawner.Instance.Spawn("CanvasBotIndicator", transform.position, Quaternion.identity).GetComponentInChildren<BotIndicator>();
        botIndicator.transform.parent.gameObject.SetActive(true);
        botIndicator.OnInit(this, transform);
    }
    public virtual String GetRandomName()
    {
        Constants.BotName[] names = (Constants.BotName[])Enum.GetValues(typeof(Constants.BotName));

        int randomIndex = UnityEngine.Random.Range(0, names.Length);

        // Set the characterName to a random value from the enum
        characterName = names[randomIndex].ToString();
        return characterName;
    }
}
