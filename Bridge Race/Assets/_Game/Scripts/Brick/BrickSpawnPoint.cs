using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BrickSpawnPoint 
{
    public Vector2Int coordinates;
    public Color color;
    public bool isSpawned;
    public BrickSpawnPoint(Vector2Int coordinates, Color color, bool isSpawned)
    {
        this.coordinates = coordinates;
        this.isSpawned = isSpawned;
        this.color = color;
    }

    public BrickSpawnPoint(Vector2Int coordinates, bool isSpawned)
    {
        this.coordinates = coordinates;
        this.isSpawned = isSpawned;
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }
}
