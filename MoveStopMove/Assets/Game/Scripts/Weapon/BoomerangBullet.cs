using UnityEngine;

public class BoomerangBullet : WeaponBullet
{
    private bool isRotate = false;
    public override void Move()
    {
        this.transform.position += moveDirection * (moveSpeed * Time.fixedDeltaTime);

        model.Rotate(Constants.BulletSpeed.ROTATION * Time.fixedDeltaTime * -Vector3.forward);
        //this.transform.Rotate(Constants.BulletSpeed.ROTATION * Time.fixedDeltaTime * -Vector3.forward);
        if (CanRotateBack() && !isRotate)
        {
            RotateBack();
            isRotate = true;
        }

        if (CanDespawn() && isRotate)
        {
            OnDespawn();
            isRotate = false;
        }
    }

    private void RotateBack()
    {
        Vector3 temp = targetPoint;
        targetPoint = startPoint;
        startPoint = temp;
        

        //Debug.Log(maxFlyDistance);
        moveDirection = new Vector3((targetPoint - this.transform.position).normalized.x, 0f, (targetPoint - this.transform.position).normalized.z);
       

        //this.transform.up = -moveDirection;
    }

    protected override bool CanDespawn()
    {
        return Vector3.Distance(startPoint, this.transform.position) >= maxFlyDistance;
    }

    protected virtual bool CanRotateBack()
    {
        return Vector3.Distance(startPoint, this.transform.position) >= maxFlyDistance;
    }

    public override void SetUp()
    {

    }
}
