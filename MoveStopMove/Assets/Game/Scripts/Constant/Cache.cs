using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cache<T>
{
    private static Dictionary<Collider, T> dict = new Dictionary<Collider, T>();
    public static T GetComponent(Collider collider)
    {
        if (dict.TryGetValue(collider, out var value))
        {
            return value;
        }
        else
        {
            T collectItems = collider.GetComponent<T>();
            dict.Add(collider, collectItems);
            return collectItems;
        }
    }
}
