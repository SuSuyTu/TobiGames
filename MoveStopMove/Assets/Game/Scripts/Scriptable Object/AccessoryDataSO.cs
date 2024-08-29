using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AccessoryData", menuName = "ScriptableObjects/AccessoryData")]
public class AccessoryDataSO : ScriptableObject
{
    public int index;
    public int price;
    public Constants.AccessoryType accessoryType;
    public Sprite icon;
    public GameObject model;
}