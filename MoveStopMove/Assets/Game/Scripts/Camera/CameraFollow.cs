using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public enum State
    {
        MainMenu = 0,
        Gameplay = 1,
        Shop = 2
    }

    [SerializeField] protected Transform target;
    [SerializeField] protected Camera mainCamera;
    // [SerializeField] private Transform tf;
    [SerializeField] private float smoothSpeed = 5f;


    [Header("Offset")]
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 offsetMax;
    [SerializeField] private Vector3 offsetMin;

    [SerializeField] private Transform[] offsets;

    private Vector3 targetOffset;
    private Quaternion targetRotate;
    private State currentState;

    private void Reset()
    {
        LoadTarget();
        LoadCamera();
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = FindObjectOfType<PlayerCtrl>().transform;
        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = UnityEngine.Camera.main;
        Debug.LogWarning(transform.name + ": LoadCamera", gameObject);
    }

    private void LateUpdate()
    {
        offset = Vector3.Lerp(offset, targetOffset, Time.deltaTime * smoothSpeed);
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, targetRotate, Time.deltaTime * smoothSpeed);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, target.position + targetOffset, Time.deltaTime * smoothSpeed);
    }

    public void OnReset()
    {
        SetRateOffset(0);
    }

    //Lerp
    public void SetRateOffset(float rate)
    {
        if (currentState == State.Gameplay)
        {
            targetOffset = Vector3.Lerp(offsetMin, offsetMax, rate);
        }
    }

    public void ChangeState(State state)
    {
        currentState = state;
        targetOffset = offsets[(int)state].localPosition;
        targetRotate = offsets[(int)state].localRotation;
    }
}
