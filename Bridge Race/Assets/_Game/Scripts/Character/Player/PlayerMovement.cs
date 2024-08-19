using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NewMonoBehaviour
{
    [SerializeField] protected FloatingJoystick floatingJoystick; 
    public FloatingJoystick FloatingJoystick => floatingJoystick;

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
