using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PantData", menuName = "ScriptableObjects/PantData")]
public class PantDataSO : ScriptableObject
{
    public int index;
    public int price;
    public Constants.PantsType pantType;

}
