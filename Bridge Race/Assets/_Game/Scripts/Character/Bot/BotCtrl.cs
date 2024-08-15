using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotCtrl : NewMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected Backpack backpack;
    public Backpack Backpack => backpack;
    [SerializeField] protected Ground ground;
    public Ground Ground => ground;
    [SerializeField] protected BotGameSession botGameSession;
    public BotGameSession BotGameSession => botGameSession;
    [SerializeField] protected NavMeshAgent navMeshAgent;
    public NavMeshAgent NavMeshAgent => navMeshAgent;
    [SerializeField] protected Color color;
    public Color Color => color;
    [SerializeField] protected UnityEngine.Color unityColor;
    public UnityEngine.Color UnityColor => unityColor;
    [SerializeField] public Vector3 velocity;
    protected override void Reset()
    {
        base.Reset();
        LoadModel();
        LoadAnimator();
        LoadGrounds();
        LoadBackpack();
        LoadBotGameSession();
        LoadNavMeshAgent();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": LoadModel", gameObject);
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }
    protected virtual void LoadGrounds()
    {
        if (this.ground != null) return;
        this.ground = FindObjectOfType<Ground>();
        Debug.LogWarning(transform.name + ": LoadGrounds", gameObject);
    }

    protected virtual void LoadBackpack()
    {
        if (this.backpack != null) return;
        this.backpack = GetComponentInChildren<Backpack>();
        Debug.LogWarning(transform.name + ": LoadBackpack", gameObject);
    }
    protected virtual void LoadBotGameSession()
    {
        if (this.botGameSession != null) return;
        this.botGameSession = GetComponentInChildren<BotGameSession>();
        Debug.LogWarning(transform.name + ": LoadBotGameSession", gameObject);
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.navMeshAgent != null) return;
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        Debug.LogWarning(transform.name + ": LoadNavMeshAgent", gameObject);
    }
}
