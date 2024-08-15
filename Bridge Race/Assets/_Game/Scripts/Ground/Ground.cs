using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : NewMonoBehaviour
{
    [SerializeField] protected List<GroundCtrl> grounds = new List<GroundCtrl>();
    public List<GroundCtrl> Grounds => grounds;

    protected override void Reset() {
        base.Reset();
        LoadGrounds();
    }

    protected virtual void LoadGrounds()
    {
        foreach (Transform child in this.gameObject.transform)
        {
            grounds.Add(child.GetComponent<GroundCtrl>());
        }
        Debug.LogWarning(transform.name + ": LoadGrounds", gameObject);
    }
}
