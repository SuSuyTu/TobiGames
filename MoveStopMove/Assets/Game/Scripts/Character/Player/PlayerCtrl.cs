using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : CharacterCtrl
{
    [Header("Player Ctrl")]
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;
    [SerializeField] protected FloatingJoystick floatingJoystick;
    public FloatingJoystick FloatingJoystick => floatingJoystick;
    [SerializeField] protected PlayerMovement playerMovement;
    public PlayerMovement PlayerMovement => playerMovement;
    [SerializeField] protected PlayerAttackRange playerAttackRange;
    public PlayerAttackRange PlayerAttackRange => playerAttackRange;
    [SerializeField] protected PlayerStateManager playerStateManager;
    public PlayerStateManager PlayerStateManager => playerStateManager;

    public int point;
    
    private BotIndicator botIndicator;
    private float tempSize;
    
    protected override void Awake()
    {
        base.Awake();
        PlayerCtrl.instance = this;

        //CharacterSkin.ChangeSkin();
    }

    protected virtual void OnEnable() 
    {
        TF.localScale = Vector3.one;
        tempSize = 1.4f;
        //size = 1;
        CameraManager.Instance.ResetGameplayCameraFOV();
        // TF.localScale = Vector3.one;
        // tempSize = 1.4f;
        // size = 1;
    }

    protected override void Reset()
    {
        base.Reset();
        LoadCurrentWeapon();
        LoadFloatingJoystick();
        LoadPlaymonement();
        LoadPlayerAttackRange();
        LoadPlayerStateManager();
    }

    protected virtual void LoadFloatingJoystick()
    {
        if (this.floatingJoystick != null) return;
        this.floatingJoystick = FindObjectOfType<FloatingJoystick>();
        Debug.LogWarning(transform.name + ": LoadFloatingJoystick", gameObject);
    }

    protected virtual void LoadPlaymonement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponentInChildren<PlayerMovement>();
        Debug.LogWarning(transform.name + ": LoadPlaymonement", gameObject);
    }

    protected virtual void LoadPlayerAttackRange()
    {
        if (this.playerAttackRange != null) return;
        this.playerAttackRange = GetComponentInChildren<PlayerAttackRange>();
        Debug.LogWarning(transform.name + ": LoadPlayerAttackRange", gameObject);
    }

    protected virtual void LoadPlayerStateManager()
    {
        if (this.playerStateManager != null) return;
        this.playerStateManager = GetComponentInChildren<PlayerStateManager>();
        Debug.LogWarning(transform.name + ": LoadPlayerStateManager", gameObject);
    }

    public override void StopMove()
    {
        base.StopMove();
        rigidBody.velocity = Vector3.zero;
    }

    public override void CharacterSizeUp()
    {
        base.CharacterSizeUp();
        PlayerFOVUp();
    }

    public virtual void PlayerFOVUp()
    {
        if (size >= tempSize)
        {
            CameraManager.Instance.IncreaseGamePlayCameraFOV();
            tempSize += 0.4f;
        }
    }
    

    public virtual void SetUpIndicator() 
    {
        //wayPointIndicator = SimplePool.Spawn<Indicator>(PoolType.Indicator, transform.position, Quaternion.identity);
        botIndicator = IndicatorSpawner.Instance.Spawn("CanvasBotIndicator", transform.position, Quaternion.identity).GetComponentInChildren<BotIndicator>();
        botIndicator.transform.parent.gameObject.SetActive(true);
        botIndicator.OnInit(this, transform);
    }
}
