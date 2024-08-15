using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : NewMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;
    [SerializeField] protected Transform model;
    public Transform Model => model; 
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;
    [SerializeField] protected Backpack backpack;
    public Backpack Backpack => backpack;
    [SerializeField] protected PlayerGameSession playerGameSession;
    public PlayerGameSession PlayerGameSession => playerGameSession;
    [SerializeField] protected Ground ground;
    public Ground Ground => ground;
    [SerializeField] protected Color color;
    public Color Color => color;
    [SerializeField] protected UnityEngine.Color unityColor;
    public UnityEngine.Color UnityColor => unityColor;
    [SerializeField] public Vector3 velocity;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null) Debug.Log("Only 1 PlayerCtrl are allow to exits");
        PlayerCtrl.instance = this;
    }
    protected override void Reset()
    {
        base.Reset();
        LoadModel();
        LoadAnimator();
        LoadPlayerMovement();
        LoadBackpack();
        LoadPlayerGameSession();
        LoadGrounds();
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

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponent<PlayerMovement>();
        Debug.LogWarning(transform.name + ": LoadPlayerMovement", gameObject);
    }
    protected virtual void LoadBackpack()
    {
        if (this.backpack != null) return;
        this.backpack = GetComponentInChildren<Backpack>();
        Debug.LogWarning(transform.name + ": LoadBackpack", gameObject);
    }

    protected virtual void LoadPlayerGameSession()
    {
        if (this.playerGameSession != null) return;
        this.playerGameSession = GetComponentInChildren<PlayerGameSession>();
        Debug.LogWarning(transform.name + ": LoadPlayerGameSession", gameObject);
    }

    protected virtual void LoadGrounds()
    {
        if (this.ground != null) return;
        this.ground = FindObjectOfType<Ground>();
        Debug.LogWarning(transform.name + ": LoadGrounds", gameObject);
    }
}
