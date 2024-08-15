using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : Spawner
{
    private static BrickSpawner instance;
    public static BrickSpawner Instance { get => instance; }
    public static string brickBlue = "Blue";
    public static string brickGreen = "Green";
    public static string brickRed = "Red";
    public static string brickYellow = "Yellow";

    protected override void Awake()
    {
        base.Awake();
        if (BrickSpawner.instance != null) Debug.LogError("Only 1 BrickSpawner allow to exist");
        BrickSpawner.instance = this;
    }
}
