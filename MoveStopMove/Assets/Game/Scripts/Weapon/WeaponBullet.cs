using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBullet : MonoBehaviour
{
    [SerializeField] protected Transform model;
    protected CharacterCtrl owner;
    protected Vector3 startPoint;
    protected Vector3 moveDirection;
    protected Vector3 targetPoint;
    public float moveSpeed;
    protected float maxFlyDistance;
    public virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void OnInit(CharacterCtrl owner, Vector3 target, float size)
    {
        // Testing 
        transform.localScale = new Vector3(size, size, size);


        this.owner = owner;

        startPoint = this.transform.position;
        
        targetPoint = target;

        maxFlyDistance = owner.CharacterAttackRange.AttackRangeRadius * Constants.CharacterAttack.DEFAULT_SPHERE_RADIUS * size;
        //Debug.Log(maxFlyDistance);
        moveDirection = new Vector3((targetPoint - this.transform.position).normalized.x, 0f, (targetPoint - this.transform.position).normalized.z);

        moveSpeed = Constants.BulletSpeed.STRAIGHT * size;
       

        this.transform.forward = moveDirection;
        Vector3 rotateWep = transform.rotation.eulerAngles;
        rotateWep = new Vector3(rotateWep.x - (float) Constants.WeaponAdjust.KnifeStraightX, rotateWep.y - (float) Constants.WeaponAdjust.KnifeStraightY, rotateWep.z);
        this.transform.rotation = Quaternion.Euler(rotateWep.x, rotateWep.y, rotateWep.z);

        SetUp();
    }


    protected void OnTriggerEnter(Collider other)
    {
        //Debug.Log(owner);
        if (other.CompareTag(Constants.TagName.CHARACTER) && owner != null)
        {
            CharacterCtrl character = Cache<CharacterCtrl>.GetComponent(other);
            //Debug.Log("Its trigger with: " + other.gameObject.name);
            // Debug.Log(owner);
            // Debug.Log(character);
            if (character != owner)
            {
                if (character is PlayerCtrl player)
                {
                    player.PlayerStateManager.SwitchState(new PlayerDeadState());
                    UIManager.Instance.SetMurderName(owner.characterName);

                }
                else if (character is BotCtrl botCtrl && !character.isDead)
                {
                    //owner.Size += 0.1f;
                    owner.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                    owner.CharacterSizeUp();
                    PlayerCtrl.Instance.point += (int) Constants.Gold.POINT;
                    
                    Transform newFX = FXSpawner.Instance.Spawn(Constants.FX.BloodVFX.ToString(), this.transform.position, Quaternion.identity);
                    newFX.gameObject.SetActive(true);
                    SoundManager.Instance.PLayWhenHit();

                    botCtrl.BotCircleTargeted.gameObject.SetActive(false);
                    botCtrl.BotStateManager.SwitchState(new BotDeadState());
                }

                OnDespawn();
            }
        }
        else if (other.CompareTag(Constants.TagName.OBSTACLE))
        {
            OnDespawn();
        }
    }

    protected virtual void OnDespawn()
    {
        transform.localScale = Vector3.one;


        BulletSpawner.Instance.Despawn(this.transform);
    }

    protected virtual bool CanDespawn()
    {
        return Vector3.Distance(startPoint, this.transform.position) >= maxFlyDistance;
    }

    public abstract void Move();
    public abstract void SetUp();
}

