using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public WeaponData weaponData;
    public virtual Transform SpawnBullet(Vector3 target, CharacterCtrl owner)
    {   
        Transform newBullet = BulletSpawner.Instance.Spawn(weaponData.name + "Bullet", owner.CharacterAttackPosition.position, Quaternion.identity);
        //Debug.Log(newBullet.name + " " + weaponData.name + "Bullet");
        SoundManager.Instance.PlayWhenAttack();
        
        //Collider other = newBullet.GetComponent<BoxCollider>();
        WeaponBullet newWeaponBullet = Cache<WeaponBullet>.GetComponent(newBullet.GetComponent<BoxCollider>());

        newWeaponBullet.OnInit(owner, target, owner.Size);
        return newBullet;
    }
}
