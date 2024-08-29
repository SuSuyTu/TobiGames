using System.Collections.Generic;
using UnityEngine;

public class SkinDataSO<T> : ScriptableObject
{
    [SerializeField] private List<T> prefabs = new List<T>();

    public T GetSkin(int index)
    {
        return prefabs[index];
    }

}
