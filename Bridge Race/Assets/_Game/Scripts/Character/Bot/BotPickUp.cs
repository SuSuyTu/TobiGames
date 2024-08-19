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
        if (other.gameObject.CompareTag("Brick") 
            && other.gameObject.GetComponent<Brick>().Color.ToString() == botCtrl.Color.ToString())
        {
            botCtrl.BotBackpack.AddStack(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Fallen Brick"))
        {
            botCtrl.BotBackpack.AddFallenStack(other.gameObject);
        }
    }
}
