using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGameSession : PlayerGameSession
{
    [SerializeField] protected BotCtrl botCtrl;
    public BotCtrl BotCtrl => botCtrl;

    protected override void Reset()
    {
        base.Reset();
        LoadBotCtrl();
    }

    protected virtual void LoadBotCtrl()
    {
        if (this.botCtrl != null) return;
        this.botCtrl = GetComponentInParent<BotCtrl>();
        Debug.LogWarning(transform.name + ": LoadBotCtrl", gameObject);
    }
    protected override void LoadGroundCtrl()
    {
        this.currentGround = botCtrl.Ground.Grounds[currentIndex];
        Debug.LogWarning(transform.name + ": LoadGroundCtrl", gameObject);
    }

    public override GroundCtrl GetNextGround()
    {
        currentIndex++;
        return botCtrl.Ground.Grounds[currentIndex];
    }
}
