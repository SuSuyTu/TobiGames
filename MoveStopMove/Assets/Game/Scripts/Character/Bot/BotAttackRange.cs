using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttackRange : CharacterAttackRange
{
    [SerializeField] protected BotCtrl botCtrl;
    protected override void CharacterEnterRange(Collider other)
    {
        CharacterCtrl characterCtrl = Cache<CharacterCtrl>.GetComponent(other);

        if (characterCtrl != null && !characterCtrl.isDead)
        {
            enemiesInRange.Add(characterCtrl);
                
        }
    }

    protected override void CharacterExitRange(Collider other)
    {
        CharacterCtrl characterCtrl = Cache<CharacterCtrl>.GetComponent(other);

        if (characterCtrl != null)
        {
            enemiesInRange.Remove(characterCtrl);
        }
    }

    public override void Attack(Vector3 targetPos)
    {
        botCtrl.LoadCurrentWeapon();
        Transform newBullet = botCtrl.CurrentWeapon.SpawnBullet(targetPos, botCtrl);
        newBullet.gameObject.SetActive(true);
        StartCoroutine(ResetAttack());
    }

    protected IEnumerator ResetAttack()
    {
        //botCtrl.LoadCurrentWeapon();
        botCtrl.IsAttackable = false;
        // botCtrl.CurrentWeapon.meshRenderer.enabled = false;
        //botCtrl.CurrentWeapon.gameObject.SetActive(false);

        yield return new WaitForSeconds(botCtrl.CurrentWeapon.weaponData.attackSpeed);

        botCtrl.IsAttackable = true;
        // botCtrl.CurrentWeapon.meshRenderer.enabled = true;
        //botCtrl.CurrentWeapon.gameObject.SetActive(true);
    }
}
