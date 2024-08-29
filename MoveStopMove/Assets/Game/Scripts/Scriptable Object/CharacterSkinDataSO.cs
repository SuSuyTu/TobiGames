using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSkinData", menuName = "ScriptableObjects/CharacterSkinData")]
public class CharacterSkinDataSO : ScriptableObject
{
    public List<Material> skinColor;
}
