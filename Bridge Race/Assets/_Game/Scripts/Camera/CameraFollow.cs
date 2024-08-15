using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : NewMonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected Vector3 offset;
    [SerializeField] protected float speed;
    protected override void Reset()
    {
        base.Reset();
        LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = FindObjectOfType<PlayerCtrl>().transform;
        Debug.LogWarning(transform.name + ": LoadPlayer", gameObject);
    }

    protected virtual void LateUpdate()
    {
        Vector3 newPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
    }
}
