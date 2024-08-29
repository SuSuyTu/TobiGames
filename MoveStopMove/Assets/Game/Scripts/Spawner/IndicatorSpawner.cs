using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorSpawner : Spawner
{
    private static IndicatorSpawner instance;
    public static IndicatorSpawner Instance => instance;
    protected virtual void Awake()
    {
        if (IndicatorSpawner.instance != null) Debug.LogError("Only 1 IndicatorSpawner allow to exist");
        IndicatorSpawner.instance = this;
    }
}
