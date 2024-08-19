using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCtrl : NewMonoBehaviour
{
    [SerializeField] protected GridManager gridManager;
    public GridManager GridManager => gridManager; 
    [SerializeField] protected BrickManager brickManager;
    public BrickManager BrickManager => brickManager; 
    [SerializeField] protected ColorManager colorManager;
    public ColorManager ColorManager => colorManager; 
    [SerializeField] protected BridgeManager bridgeManager;
    public BridgeManager BridgeManager => bridgeManager;
    protected override void Reset()
    {
        base.Reset();
        LoadGridManager();
        LoadBrickManager();
        LoadColorManager();
        LoadBridgeManager();
    }

    protected virtual void LoadGridManager()
    {
        if (this.gridManager != null) return;
        this.gridManager = GetComponentInChildren<GridManager>();
        Debug.LogWarning(transform.name + ": LoadGridManager", gameObject);
    }
    protected virtual void LoadBrickManager()
    {
        if (this.brickManager != null) return;
        this.brickManager = GetComponentInChildren<BrickManager>();
        Debug.LogWarning(transform.name + ": LoadBrickManager", gameObject);
    }

    protected virtual void LoadColorManager()
    {
        if (this.colorManager != null) return;
        this.colorManager = GetComponentInChildren<ColorManager>();
        Debug.LogWarning(transform.name + ": LoadColorManager", gameObject);
    }

    protected virtual void LoadBridgeManager()
    {
        if (this.bridgeManager != null) return;
        this.bridgeManager = GetComponentInChildren<BridgeManager>();
        Debug.LogWarning(transform.name + ": LoadBridgeManager", gameObject);
    }
}
