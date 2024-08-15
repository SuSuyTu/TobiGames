using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : NewMonoBehaviour
{
    [SerializeField] protected List<Color> colorSpawnList;
    public List<Color> ColorSpawnList => colorSpawnList;

    public virtual void AddToList(Color charactorColor)
    {
        colorSpawnList.Add(charactorColor);
    }

    public virtual void RemoveFromList(Color charactorColor)
    {
        colorSpawnList.Remove(charactorColor);
    }
}
