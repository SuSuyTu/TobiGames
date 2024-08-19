using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : NewMonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] protected Transform player;
    [SerializeField] protected Vector3 offset;
    [SerializeField] protected float speed;
    public float smoothSpeed = 0.125f;
    public float smoothLerp = 0;
    public float levelFinishedSmoothSpeed = 25f;
    private float lerpTime;
    public float rotationSpeed = 0.5f;
    public bool isRotate = false;
    public bool isLevelFinished = false;
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
        if (isLevelFinished && isRotate)
        {
            // Level is finished And Camera rotating around the winner
            transform.RotateAround(player.position, Vector3.up, rotationSpeed * Time.deltaTime);

            transform.LookAt(player.position);
            return;
        }
        else if (isLevelFinished && !isRotate)
        {
            // Level is finished And Camera moving toward the winner

            Vector3 desiredPosition = player.position + (offset / 2);
            lerpTime += Time.deltaTime * levelFinishedSmoothSpeed;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, lerpTime);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;

            _camera.fieldOfView += levelFinishedSmoothSpeed * Time.deltaTime;
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 60f, 70f);

            if (Vector3.Distance(transform.position, desiredPosition) <= 0.1f)
            {
                isRotate = true;
                _camera.fieldOfView = 60f;
            }
        }
        else 
        {
            Vector3 desiredPosition = player.position + offset;

            smoothLerp += Time.deltaTime * smoothSpeed;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothLerp);

            if (transform.position == smoothedPosition)
                smoothLerp = 0f;
            // Set the camera's position to the smoothed position
            transform.position = desiredPosition;
            //Vector3 newPosition = player.position + offset;
            //transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
    }

    public void LevelFinished(Transform _winnerTarget)
    {
        isLevelFinished = true;
        player = _winnerTarget;
        offset = new Vector3(-10, 6, 0);
        _camera.transform.rotation = Quaternion.Euler(20, 180, 0);

        lerpTime = 0;
    }
}
