using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAttackRange : MonoBehaviour
{
    [SerializeField] protected float attackRangeRadius;
    public float AttackRangeRadius => attackRangeRadius;
    [SerializeField] protected List<CharacterCtrl> enemiesInRange = new List<CharacterCtrl>();
    public List<CharacterCtrl> EnemiesInRange => enemiesInRange;
    public bool FoundCharacter => enemiesInRange.Count > 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.TagName.CHARACTER))
        {
            CharacterEnterRange(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constants.TagName.CHARACTER))
        {
            CharacterExitRange(other);
        }
    }

    protected virtual void FixedUpdate()
    {
        
        // foreach (CharacterCtrl characterCtrl in enemiesInRange)
        // {
        //     if (characterCtrl.isDead)
        //     {
        //         enemiesInRange.Remove(characterCtrl);
        //     }
        // }
        for (int i = enemiesInRange.Count - 1; i >= 0; i--)
        {
            if (enemiesInRange[i].isDead)
            {
                enemiesInRange.RemoveAt(i);
            }
        }
    }
    protected abstract void CharacterEnterRange(Collider other);
    protected abstract void CharacterExitRange(Collider other);
    public abstract void Attack(Vector3 targetPosition);
}
