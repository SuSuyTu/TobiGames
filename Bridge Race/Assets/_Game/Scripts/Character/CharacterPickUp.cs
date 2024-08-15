using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CharacterPickUp : NewMonoBehaviour
{
    // [SerializeField] protected Rigidbody rigidBody;
    [SerializeField] protected BoxCollider boxCollider;
    protected override void Reset()
    {
        base.Reset();
        LoadCollider();
        // LoadRigidBody();
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        this.boxCollider.center = new Vector3(0.003189862f, 1.215329f, -0.004276037f);
        this.boxCollider.size = new Vector3(0.7320975f, 2.371392f, 0.7372546f);
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    // protected virtual void LoadRigidBody()
    // {
    //     if (this.rigidBody != null) return;
    //     this.rigidBody = GetComponent<Rigidbody>();
    //     this.rigidBody.useGravity = false;
    //     this.rigidBody.isKinematic = true;
    //     Debug.LogWarning(transform.name + ": LoadRigidBody", gameObject);
    // }

    protected virtual void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Brick") 
            && other.gameObject.GetComponent<Brick>().Color.ToString() == PlayerCtrl.Instance.Color.ToString())
        {
            PlayerCtrl.Instance.Backpack.AddStack(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Fallen Brick"))
        {
            PlayerCtrl.Instance.Backpack.AddFallenStack(other.gameObject);
        }

        if (other.gameObject.CompareTag("NextStage"))
        {
            EnterNextGround();

            other.gameObject.SetActive(false);
        }
    }

    protected virtual void EnterNextGround()
    {
        PlayerCtrl.Instance.PlayerGameSession.CurrentColorManager.RemoveFromList(PlayerCtrl.Instance.Color);
        PlayerCtrl.Instance.PlayerGameSession.CurrentBrickManager.RemoveColor(PlayerCtrl.Instance.Color);

        PlayerCtrl.Instance.PlayerGameSession.SetCurrentGround(PlayerCtrl.Instance.PlayerGameSession.GetNextGround());
        PlayerCtrl.Instance.PlayerGameSession.FindCurrentManager();

        PlayerCtrl.Instance.PlayerGameSession.CurrentColorManager.AddToList(PlayerCtrl.Instance.Color);
        PlayerCtrl.Instance.PlayerGameSession.CurrentBrickManager.IsStartOfTheStage();
    }
}
