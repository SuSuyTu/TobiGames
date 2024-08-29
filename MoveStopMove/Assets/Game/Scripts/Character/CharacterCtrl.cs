using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MonoBehaviour
{
    private static CharacterCtrl characterCtrlInstance;
    public static CharacterCtrl CharacterCtrllInstance => characterCtrlInstance;

    [Header("CharacterCtrl")]

    [Header("Body")]
    [SerializeField] protected Rigidbody rigidBody;
    public Rigidbody Rigidbody => rigidBody;
    [SerializeField] protected BoxCollider boxCollider;
    public BoxCollider BoxCollider => boxCollider;
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected float size;

    [Header("Attack")]
    [SerializeField] protected bool isAttackable = true;
    [SerializeField] protected bool isAttacking = false;
    [SerializeField] protected Weapon currentWeapon;
    public Weapon CurrentWeapon => currentWeapon;
    [SerializeField] protected CharacterAttackRange characterAttackRange;
    public CharacterAttackRange CharacterAttackRange => characterAttackRange;
    [SerializeField] protected Transform characterAttackPosition;
    public Transform CharacterAttackPosition => characterAttackPosition;
    public bool isDead;
    public Transform TF;


    [Header("Skin")]
    [SerializeField] protected CharacterSkin characterSkin;
    public CharacterSkin CharacterSkin => characterSkin;

    [Header("Name")]
    [HideInInspector] public string characterName;

    public bool IsAttackable
    {
        get => isAttackable;
        set => isAttackable = value;
    }

    public bool IsAttacking
    {
        get => isAttacking;
        set => isAttacking = value;
    }

    public float Size
    {
        get => size;
        set => size = value;
    }

    protected virtual void Awake()
    {
        CharacterCtrl.characterCtrlInstance = this;
    }
    // protected virtual void Start()
    // {
    //     LoadCurrentWeapon();
    // }
    protected virtual void Reset()
    {
        LoadAnimator();
        LoadRigidBody();
        LoadBoxCollider();
        LoadCharacterAttackRange();
        LoadCharacterSkin();
        LoadAttackPosition();
    }

    protected virtual void LoadRigidBody()
    {
        if (this.rigidBody != null) return;
        this.rigidBody = GetComponent<Rigidbody>();
        Debug.LogWarning(transform.name + ": LoadRigidBody", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
        Debug.LogWarning(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        Debug.LogWarning(transform.name + ": LoadBoxCollider", gameObject);
    }

    protected virtual void LoadCharacterAttackRange()
    {
        if (this.characterAttackRange != null) return;
        this.characterAttackRange = GetComponentInChildren<CharacterAttackRange>();
        Debug.LogWarning(transform.name + ": LoadCharacterAttackRange", gameObject);
    }

    public virtual void LoadCurrentWeapon()
    {
        //if (this.currentWeapon != null) return;
        //this.currentWeapon = GetComponentInChildren<Weapon>();
        this.currentWeapon = characterSkin.RightHand.GetComponentInChildren<Weapon>();
        Debug.LogWarning(transform.name + ": LoadCurrentWeapon", gameObject);
    }
    protected virtual void LoadCharacterSkin()
    {
        if (this.characterSkin != null) return;
        this.characterSkin = GetComponentInChildren<CharacterSkin>();
        Debug.LogWarning(transform.name + ": LoadCharacterSkin", gameObject);
    }

    public virtual void CharacterSizeUp()
    {
        TF.localScale = new Vector3(size, size, size);
    }

    protected virtual void LoadAttackPosition()
    {
    }

    public virtual void StopMove()
    {

    }

    
}
