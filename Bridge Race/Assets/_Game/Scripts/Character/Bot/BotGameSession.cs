using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGameSession : NewMonoBehaviour
{
    [SerializeField] protected BotCtrl botCtrl;
    public BotCtrl BotCtrl => botCtrl;

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

    [SerializeField] protected int currentBotIndex;
    
    protected override void Reset()
    {
        base.Reset();
        LoadBotCtrl();
    }
    
    protected override void Start()
    {
        base.Start(); 
        LoadGroundCtrl();
        FindCurrentManager();
    }

    public virtual void FindCurrentManager()
    {
        currentGridManager = currentGround.transform.GetChild(0).gameObject.GetComponent<GridManager>();
        currentBrickManager = currentGround.transform.GetChild(1).gameObject.GetComponent<BrickManager>();
        currentColorManager = currentGround.transform.GetChild(2).gameObject.GetComponent<ColorManager>();
        currentBridgeManager = currentGround.transform.GetChild(3).gameObject.GetComponent<BridgeManager>();
    }

    protected virtual void LoadBotCtrl()
    {
        if (this.botCtrl != null) return;
        this.botCtrl = GetComponentInParent<BotCtrl>();
        Debug.LogWarning(transform.name + ": LoadBotCtrl", gameObject);
    }
    protected virtual void LoadGroundCtrl()
    {
        this.currentGround = botCtrl.Ground.Grounds[currentBotIndex];
        Debug.LogWarning(transform.name + ": LoadGroundCtrl", gameObject);
    }

    public virtual GroundCtrl GetNextGround()
    {
        currentBotIndex++;
        if (currentBotIndex == botCtrl.Ground.Grounds.Count)
        {
            currentBotIndex--;
        }
        return botCtrl.Ground.Grounds[currentBotIndex];
    }

    public virtual void SetCurrentGround(GroundCtrl groundCtrl)
    {
        this.currentGround = groundCtrl;
    }
}
