using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFacePlayer : MonoBehaviour
{
    public Transform playerCamera;

    Vector3 lookAtPosition;

    protected virtual void Update() 
    {
        if (playerCamera != null)
        {
            lookAtPosition = new Vector3(playerCamera.position.x, transform.position.y, playerCamera.position.z);

            transform.LookAt(lookAtPosition);

            transform.forward = -transform.forward;
        }    
    }
}
