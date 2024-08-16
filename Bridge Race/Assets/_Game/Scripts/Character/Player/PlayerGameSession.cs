using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameSession : NewMonoBehaviour
{
    [SerializeField] protected GroundCtrl currentGround;
    public GroundCtrl CurrentGround => currentGround;
    [SerializeField] protected GridManager currentGridManager;
    public GridManager CurrentGridManager => currentGridManager;
    [SerializeField] protected BrickManager currentBrickManager;
    public BrickManager CurrentBrickManager => currentBrickManager;
    [SerializeField] protected ColorManager currentColorManager;
    public ColorManager CurrentColorManager => currentColorManager;
    [SerializeField] protected BridgeManager currentBridgeManager;
    public BridgeManager CurrentBridgeManager => currentBridgeManager;
    [SerializeField] protected int currentIndex = 0;
    public int CurrentIndex => currentIndex;
    protected override void Start()
    {
        base.Start(); 
        LoadGroundCtrl();
        FindCurrentManager();
    }

    protected virtual void LoadGroundCtrl()
    {
        this.currentGround = PlayerCtrl.Instance.Ground.Grounds[currentIndex];
        Debug.LogWarning(transform.name + ": LoadGroundCtrl", gameObject);
    }

    public virtual void FindCurrentManager()
    {
        currentGridManager = currentGround.transform.GetChild(0).gameObject.GetComponent<GridManager>();
        currentBrickManager = currentGround.transform.GetChild(1).gameObject.GetComponent<BrickManager>();
        currentColorManager = currentGround.transform.GetChild(2).gameObject.GetComponent<ColorManager>();
        currentBridgeManager = currentGround.transform.GetChild(3).gameObject.GetComponent<BridgeManager>();
    }

    public virtual void SetCurrentGround(GroundCtrl groundCtrl)
    {
        this.currentGround = groundCtrl;
    }
    public virtual GroundCtrl GetNextGround()
    {
        currentIndex++;
        return PlayerCtrl.Instance.Ground.Grounds[currentIndex];
    }
}
