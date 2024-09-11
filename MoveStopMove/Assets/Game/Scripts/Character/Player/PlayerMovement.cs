using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    private XRIDefaultInputActions playerMovement;
    private Vector2 moveInput;

    private void Awake()
    {
        playerMovement = new XRIDefaultInputActions();

        // Bind the movement and look actions
        playerMovement.XRILeftHandLocomotion.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerMovement.XRILeftHandLocomotion.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (!PlayerCtrl.Instance.isDead && !PlayerCtrl.Instance.IsAttacking)
        {
            Vector3 movement = new Vector3(moveInput.x * moveSpeed, 0, moveInput.y * moveSpeed);
            PlayerCtrl.Instance.Rigidbody.velocity = movement;

            if (CheckInput())
            {
                transform.parent.rotation = Quaternion.LookRotation(movement);
            }
        }
        else
        {
            PlayerCtrl.Instance.Rigidbody.velocity = Vector3.zero;
        }
    }

    public virtual bool CheckInput()
    {
        return moveInput.x != 0 || moveInput.y != 0;
    }

    public void RotateTo(Vector3 target)
    {
        Vector3 direction = target - transform.parent.position;
        direction.y = 0;
        transform.parent.forward = direction.normalized;
    }

    // [SerializeField] protected float moveSpeed;
    // protected virtual void FixedUpdate()
    // {
    //     Move();
    // }

    // protected virtual void Move()
    // {
    //     if (!PlayerCtrl.Instance.isDead && !PlayerCtrl.Instance.IsAttacking)
    //     {
    //         PlayerCtrl.Instance.Rigidbody.velocity = new Vector3(PlayerCtrl.Instance.FloatingJoystick.Horizontal * moveSpeed,
    //                                                             0,
    //                                                             PlayerCtrl.Instance.FloatingJoystick.Vertical * moveSpeed);
    //     }
    //     else
    //     {
    //         PlayerCtrl.Instance.Rigidbody.velocity = Vector3.zero;
    //     }
        
    //     if (CheckInput())
    //     {
    //         transform.parent.rotation = Quaternion.LookRotation(PlayerCtrl.Instance.Rigidbody.velocity);
    //     }
    // }

    // public virtual bool CheckInput()
    // {
    //     return PlayerCtrl.Instance.FloatingJoystick.Horizontal != 0 || PlayerCtrl.Instance.FloatingJoystick.Vertical != 0;
    // }

    // public void RotateTo(Vector3 target)
    // {
    //     Vector3 tmpPos = target - transform.parent.position;
    //     tmpPos.y = 0;
    //     transform.parent.forward = tmpPos.normalized;
    // }

    // private void OnStartMove()
    //     {
    //         if (startMove == false)
    //         {
    //             startMove = true;
    //             UIManager.Instance.GetUI<UIGameplay>().HideTutorial();
    //         }
    //     }
}
