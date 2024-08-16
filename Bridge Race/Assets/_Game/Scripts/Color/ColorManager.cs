using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : NewMonoBehaviour
{
    [SerializeField] protected List<Color> colorSpawnList;
    public List<Color> ColorSpawnList => colorSpawnList;
    [SerializeField] protected Color spawnNewGroundColor;
    public Color SpawnNewGroundColor => spawnNewGroundColor;

    public virtual void AddToList(Color charactorColor)
    {
        colorSpawnList.Add(charactorColor);
        spawnNewGroundColor = charactorColor;
    }

    public virtual void RemoveFromList(Color charactorColor)
    {
        colorSpawnList.Remove(charactorColor);
    }

    public virtual void RemoveFromSpawnNewGround(int index)
    {
        colorSpawnList.RemoveAt(index);
    }
}
