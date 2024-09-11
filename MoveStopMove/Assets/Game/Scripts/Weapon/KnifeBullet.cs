using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBullet : WeaponBullet
{
    public override void Move()
    {
        //moveDirection = (targetPoint - this.transform.position).normalized;
        this.transform.position += moveDirection  * Time.fixedDeltaTime * moveSpeed;

        if (CanDespawn())
        {
            OnDespawn();
        }
    }

    public override void SetUp()
    {
        maxFlyDistance *= 0.8f;
    }
}
