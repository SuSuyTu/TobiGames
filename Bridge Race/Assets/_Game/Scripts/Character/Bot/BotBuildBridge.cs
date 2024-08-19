using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotBuildBridge : NewMonoBehaviour
{
    [SerializeField] protected BotCtrl botCtrl;
    protected virtual void  FixedUpdate() 
    {
        Build();
    }

    protected virtual void Build()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.CompareTag("Step"))
            {
                MeshRenderer stepMeshRenderer = hit.transform.GetComponent<MeshRenderer>();
                BoxCollider stopBoxCollider = hit.transform.GetChild(0).GetComponent<BoxCollider>();
                if (stepMeshRenderer != null)
                {
                    if (botCtrl.BotBackpack.BotBrickStack.Count > 0)
                    {
                        stopBoxCollider.enabled = false;

                        if (!stepMeshRenderer.enabled)
                        {
                            stepMeshRenderer.enabled = true;
                        }

                        if (stepMeshRenderer.material.color != botCtrl.UnityColor)
                        {
                            stepMeshRenderer.material.color = botCtrl.UnityColor;
                            botCtrl.BotBackpack.RemoveStack();
                        }
                    }
                }
            }
        }
    }
}
