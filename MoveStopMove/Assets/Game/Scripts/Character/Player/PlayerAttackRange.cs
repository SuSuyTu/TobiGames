using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : CharacterAttackRange
{
    public SpriteRenderer circle;
    [SerializeField] protected SphereCollider sphereCollider;
    public virtual void TuneRangeBaseOnWeapon()
    {
        float size = PlayerCtrl.Instance.CurrentWeapon.weaponData.range;
        circle.size = new Vector2(size, size);
        sphereCollider.radius = PlayerCtrl.Instance.CurrentWeapon.weaponData.sphereRadius;
    }

    protected override void CharacterEnterRange(Collider other)
    {
        BotCtrl botCtrl = Cache<BotCtrl>.GetComponent(other);
        //Debug.Log(botCtrl.transform.name);

        if (botCtrl != null && !botCtrl.isDead)
        {
            botCtrl.BotCircleTargeted.SetActive(true);
            enemiesInRange.Add(botCtrl);
            //owner.OnCharacterEnterRange(enemy);
                
        }
        //Debug.Log(botCtrl.transform.position);
        //Debug.Log(enemiesInRange.Count);
    }

    protected override void CharacterExitRange(Collider other)
    {
        BotCtrl botCtrl = Cache<BotCtrl>.GetComponent(other);

        if (botCtrl != null)
        {
            botCtrl.BotCircleTargeted.SetActive(false);
            enemiesInRange.Remove(botCtrl);
            //owner.OnCharacterExitRange(enemy);
                
        }
    }



    public override void Attack(Vector3 targetPos)
    {
        Transform newBullet = PlayerCtrl.Instance.CurrentWeapon.SpawnBullet(targetPos, PlayerCtrl.Instance);
        newBullet.gameObject.SetActive(true);
        StartCoroutine(ResetAttack());
    }

    protected IEnumerator ResetAttack()
    {
        PlayerCtrl.Instance.IsAttackable = false;
        PlayerCtrl.Instance.CurrentWeapon.gameObject.SetActive(false);

        yield return new WaitForSeconds(PlayerCtrl.Instance.CurrentWeapon.weaponData.attackSpeed);

        PlayerCtrl.Instance.IsAttackable = true;
        PlayerCtrl.Instance.CurrentWeapon.gameObject.SetActive(true);
    }
}
