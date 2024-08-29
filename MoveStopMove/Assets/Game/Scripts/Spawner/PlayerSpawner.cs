using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{
    private static PlayerSpawner instance;
    public static PlayerSpawner Instance => instance; 
    protected virtual void Awake()
    {
        if (PlayerSpawner.instance != null) Debug.LogError("Only 1 PlayerSpawner allow to exist");
        PlayerSpawner.instance = this;
    }
}
