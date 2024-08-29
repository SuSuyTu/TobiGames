using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "ScriptableObjects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public int index;
    public new string name;
    public Sprite icon;

    public int price;
    public float range;
    public float moveSpeed;
    public float attackSpeed;
}
