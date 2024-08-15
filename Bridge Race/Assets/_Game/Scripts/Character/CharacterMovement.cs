using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : NewMonoBehaviour
{
    [Header("Character Movement")]
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }

    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public virtual void SetTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, this.speed);
        transform.parent.position = newPos;
    }
}
