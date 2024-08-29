using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (!PlayerCtrl.Instance.isDead && !PlayerCtrl.Instance.IsAttacking)
        {
            PlayerCtrl.Instance.Rigidbody.velocity = new Vector3(PlayerCtrl.Instance.FloatingJoystick.Horizontal * moveSpeed,
                                                                0,
                                                                PlayerCtrl.Instance.FloatingJoystick.Vertical * moveSpeed);
        }
        else
        {
            PlayerCtrl.Instance.Rigidbody.velocity = Vector3.zero;
        }
        
        if (CheckInput())
        {
            transform.parent.rotation = Quaternion.LookRotation(PlayerCtrl.Instance.Rigidbody.velocity);
        }
    }

    public virtual bool CheckInput()
    {
        return PlayerCtrl.Instance.FloatingJoystick.Horizontal != 0 || PlayerCtrl.Instance.FloatingJoystick.Vertical != 0;
    }

    public void RotateTo(Vector3 target)
    {
        Vector3 tmpPos = target - transform.parent.position;
        tmpPos.y = 0;
        transform.parent.forward = tmpPos.normalized;
    }

    // private void OnStartMove()
    //     {
    //         if (startMove == false)
    //         {
    //             startMove = true;
    //             UIManager.Instance.GetUI<UIGameplay>().HideTutorial();
    //         }
    //     }
}
