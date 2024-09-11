using UnityEngine;

public class HammerBullet : WeaponBullet
{
    public override void Move()
    {
        this.transform.position += moveDirection * (moveSpeed * Time.fixedDeltaTime);

        model.Rotate(Constants.BulletSpeed.ROTATION * Time.fixedDeltaTime * -Vector3.forward);
        //this.transform.Rotate(Constants.BulletSpeed.ROTATION * Time.fixedDeltaTime * -Vector3.forward);
        if (CanDespawn())
        {
            OnDespawn();
        }
    }

    public override void SetUp()
    {

    }
}
