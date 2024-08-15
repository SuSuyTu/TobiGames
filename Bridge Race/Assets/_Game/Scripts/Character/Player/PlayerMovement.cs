using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NewMonoBehaviour
{
    [SerializeField] protected FloatingJoystick floatingJoystick; 
    public FloatingJoystick FloatingJoystick => floatingJoystick;
    // [SerializeField] protected LayerMask groundLayer;
    // [SerializeField] protected Transform rayCastPoint;
    // [SerializeField] float groundDistance;   
    // [SerializeField] protected float moveSpeed;
    // [SerializeField] protected float rotateSpeed;
    // [SerializeField] protected bool isGrounded; 
    
    // private Vector3 moveVector;

    // protected virtual void Update()
    // {
    //     Move();
    // }

    // public virtual void Move()
    // {
    //     moveVector = Vector3.zero;
        
    //     isGrounded = Physics.CheckSphere(rayCastPoint.position, groundDistance, groundLayer);
        
    //     if ((floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0) && isGrounded)
    //     {
    //         moveVector.x = floatingJoystick.Horizontal * moveSpeed * Time.deltaTime;
    //         moveVector.z = floatingJoystick.Vertical * moveSpeed * Time.deltaTime;
    //         Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.fixedDeltaTime, 0.0f);
    //         transform.parent.rotation = Quaternion.LookRotation(direction);
    //         //transform.rotation = Quaternion.LookRotation(direction);
    //     }


    //     transform.parent.position += moveVector;;
    //     //transform.position += moveVector;
    // }

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private CharacterController characterController;
    public Vector3 velocity;
    public float gravity;
    public bool isGrounded;
    public float groundDistance;
    public LayerMask groundLayer;
    public GameObject raycastPoint;

    void Update()
    {
        if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
        {
            PlayerMove();
            PlayerRotate();
        }
    }

    private void PlayerMove()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundLayer);

        if(isGrounded && !raycastPoint.activeInHierarchy)
        {
            raycastPoint.SetActive(true);
        }

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        characterController.Move(new Vector3(floatingJoystick.Horizontal * moveSpeed, 0, floatingJoystick.Vertical * moveSpeed));
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void PlayerRotate()
    {
        float angle = Mathf.Atan2(floatingJoystick.Vertical, floatingJoystick.Horizontal) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0, -angle + 90, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.8f);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(raycastPoint.transform.position, groundDistance);
    }
}
