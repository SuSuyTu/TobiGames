using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGround : NewMonoBehaviour
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Player"))
        {
            // foreach (MeshRenderer mesh in railsMeshRenderers)
            // {
            //     mesh.material = other.GetComponent<PlayerController>().playerProperty.m_Material;
            // }
            // other.GetComponent<PlayerCtrl>().MoveToFinishPos(finishPos);
            Camera.main.GetComponent<CameraFollow>().LevelFinished(other.gameObject.transform);

            if (other.GetComponent<PlayerCtrl>() != null)
            {
                UIManager.Instance.OnLevelCompleted();
            }
            else
            {
                UIManager.Instance.OnLevelFailed();
            }

        }
    }
}
