using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FullSetData", menuName = "ScriptableObjects/FullSetData")]
public class SkinSetDataSO : ScriptableObject
{
    public int index;
    public int price;
    public Constants.SetType setType;
    public Material Skin;
    public GameObject Hat;
    public GameObject LeftHand;
    public GameObject Tail;
    public GameObject Back;
}
