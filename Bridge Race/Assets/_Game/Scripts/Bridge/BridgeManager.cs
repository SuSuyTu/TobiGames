using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeManager : NewMonoBehaviour
{
    [SerializeField] protected List<Bridge> bridges = new List<Bridge>();

    protected override void Reset()
    {
        base.Reset();
        LoadBridges();
    }

    protected virtual void LoadBridges()
    {
        //if (this.bridges != null) return;
        foreach (Transform bridge in this.transform)
        {
            bridges.Add(bridge.GetComponent<Bridge>());
        }
    }

    protected virtual void FixedUpdate() {
        RemoveFinishedBridge();
    }

    public virtual Bridge GetRadomBridge()
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(bridges.Count);
        return bridges[randomIndex];
    }

    public virtual int GetNumOfStep()
    {
        return bridges[0].Steps.Count;
    }

    protected virtual void RemoveFinishedBridge()
    {
        foreach (Bridge bridge in bridges)
        {
            if (bridge.IsFinished)
            {
                bridges.Remove(bridge);
            }
        }
    }
}
