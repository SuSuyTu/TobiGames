using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : NewMonoBehaviour
{
    [SerializeField] protected List<Transform> steps; 
    public List<Transform> Steps => steps;

    [SerializeField] protected Transform startPoint;
    public Transform StartPoint => startPoint;

    [SerializeField] protected Transform nextStagePoint;
    public Transform NextStagePoint => nextStagePoint;

    [SerializeField] protected bool isFinished;
    public bool IsFinished => isFinished;

    protected override void Reset()
    {
        base.Reset();
        LoadNumberOfSteps();
        LoadStartPoint();
        LoadNextStagePoint();
    }

    protected virtual void LoadNumberOfSteps()
    {
        Transform stepList = transform.Find("Steps");
        foreach (Transform step in stepList)
        {
            steps.Add(step.transform);
        }
        Debug.LogWarning(transform.name + ": LoadNumberOfSteps", gameObject);
    }

    protected virtual void LoadStartPoint()
    {
        if (this.startPoint != null) return;
        this.startPoint = transform.Find("BridgeStartPoint");
        Debug.LogWarning(transform.name + ": LoadStartPoint", gameObject);
    }
    protected virtual void LoadNextStagePoint()
    {
        if (this.nextStagePoint != null) return;
        this.nextStagePoint = transform.Find("NextStage");
        Debug.LogWarning(transform.name + ": LoadNextStagePoint", gameObject);
    }

    public virtual void SetIsFinished(bool isFinished)
    {
        this.isFinished = isFinished;
    }
}
