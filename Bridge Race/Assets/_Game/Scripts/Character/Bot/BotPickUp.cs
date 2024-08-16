using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPickUp : CharacterPickUp
{
    [SerializeField] protected BotCtrl botCtrl;
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
    protected override void OnTriggerEnter(Collider other) 
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Brick") 
            && other.gameObject.GetComponent<Brick>().Color.ToString() == botCtrl.Color.ToString())
        {
            botCtrl.BotBackpack.AddStack(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Fallen Brick"))
        {
            botCtrl.BotBackpack.AddFallenStack(other.gameObject);
        }

        // if (other.gameObject.CompareTag("NextStage"))
        // {
        //     EnterNextGround();

        //     other.gameObject.SetActive(false);
        // }
    }

    // protected override void EnterNextGround()
    // {
    //     botCtrl.BotGameSession.CurrentColorManager.RemoveFromList(botCtrl.Color);
    //     botCtrl.BotGameSession.CurrentBrickManager.RemoveColor(botCtrl.Color);

    //     botCtrl.BotGameSession.SetCurrentGround(botCtrl.BotGameSession.GetNextGround());
    //     botCtrl.BotGameSession.FindCurrentManager();

    //     botCtrl.BotGameSession.CurrentColorManager.AddToList(botCtrl.Color);
    //     botCtrl.BotGameSession.CurrentBrickManager.IsStartOfTheStage();
    // }
}
