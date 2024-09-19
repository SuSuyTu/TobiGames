using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;
    public static CameraManager Instance => instance;

    [SerializeField] protected CinemachineVirtualCamera skinShopCamera;
    public CinemachineVirtualCamera SkinShopCamera => skinShopCamera;
    [SerializeField] protected CinemachineVirtualCamera gamePlayCamera;
    public CinemachineVirtualCamera GamePlayCamera => gamePlayCamera;
    [SerializeField] protected CinemachineVirtualCamera resultCamera;
    public CinemachineVirtualCamera ResultCamera => resultCamera;

    protected virtual void Awake()
    {
        if (CameraManager.instance != null) Debug.LogWarning("Only 1 CameraManager allow to exist");
        CameraManager.instance = this;
    }
    public virtual void SetSkinShopCamera()
    {
        skinShopCamera.Priority = 10;
        gamePlayCamera.Priority = 5;
        resultCamera.Priority = 5;
    }

    public virtual void SetGamePlayCamera()
    {
        skinShopCamera.Priority = 5;
        gamePlayCamera.Priority = 10;
        resultCamera.Priority = 5;
    }

    public virtual void SetResultCamera()
    {
        skinShopCamera.Priority = 5;
        gamePlayCamera.Priority = 5;
        resultCamera.Priority = 10;
    }

    public virtual void ResetGameplayCameraFOV()
    {
        gamePlayCamera.m_Lens.FieldOfView = (int) Constants.Camera.DEFAULT_GAMEPLAY_CAMERA_FOV;
    }

    public virtual void IncreaseGamePlayCameraFOV()
    {
        gamePlayCamera.m_Lens.FieldOfView += (int) Constants.Camera.FOV_PER_SIZE;
    }
}
