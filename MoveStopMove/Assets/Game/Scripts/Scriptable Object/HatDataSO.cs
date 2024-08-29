using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HatData", menuName = "ScriptableObjects/HatData")]
public class HatDataSO : ScriptableObject
{
    public int index;
    public int price;
    public Constants.HatType hatType;
    public Sprite icon;
    public GameObject model;
}
