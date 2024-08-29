using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class CharacterSkin : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected Animator anim;
    [SerializeField] protected Transform head;
    [SerializeField] protected Transform rightHand;
    public Transform RightHand => rightHand;
    [SerializeField] protected Transform leftHand;
    [SerializeField] protected Transform tail;
    [SerializeField] protected Transform back;
    [SerializeField] protected Renderer pants;

    [SerializeField] protected SkinnedMeshRenderer skinRenderer;
    public SkinnedMeshRenderer SkinRenderer => skinRenderer;

    [Header("SkinData")]
    // [SerializeField] private SkinDataSO<Hat> headSkin;
    // [SerializeField] private SkinDataSO<Accessory> leftHandSkin;
    // [SerializeField] private SkinDataSO<Weapon> rightHandSkin;
    [SerializeField] protected SkinDataSO<Material> pantsSkin;
    [SerializeField] protected SkinSetDataSO[] fullsetData;

    protected CharacterCtrl owner;
    protected Transform currentHat;
    protected Transform currentAccessory;
    protected Transform currentWeapon;
    protected Transform currentSet;
    protected Renderer currentPants;
    protected Transform currentBack;
    protected Transform currentTail;


    //public bool CanChangeClothes => owner.CurrentSetType == SetType.Normal;

    // public virtual void OnInit(Character character)
    // {
    //     TakeOffClothes();
    //     owner = character;
    //     currentWeapon = owner.CurrentWeapon;
    //     currentPants = pants;

    //     WearClothes();
    // }
    public virtual void ChangeSkin()
    {

    }

    public virtual void WearClothes()
    {
        TakeOffClothes();
    }

    public virtual void TakeOffClothes()
    {
        DespawnHat();
        DespawnPants();
        DespawnAccessory();
        DespawnWeapon();
    }

    public virtual void ChangeSkinColor(Material material)
    {
        skinRenderer.material = material;
    }

    public virtual void ChangeHat(string hatType)
    {
        if (hatType.Equals("None")) return;
        DespawnHat();
        currentHat = SkinSpawner.Instance.SpawnInParent(hatType, head);
        currentHat.gameObject.SetActive(true);

    }

    public virtual void ChangeAccessory(string accessoryType)
    {
        if (accessoryType.Equals("None")) return;
        DespawnAccessory();
        currentAccessory = SkinSpawner.Instance.SpawnInParent(accessoryType, leftHand);
        currentAccessory.gameObject.SetActive(true);
    }

    public virtual void ChangeWeapon(string weaponType)
    {
        DespawnWeapon();
        currentWeapon = SkinSpawner.Instance.SpawnInParent(weaponType, rightHand);
        currentWeapon.gameObject.SetActive(true);

    }

    public virtual void ChangePants(Constants.PantsType pantType)
    {
        if (!currentPants && pantType != Constants.PantsType.Default) //(CanChangeClothes &&
        {
            pants.material = pantsSkin.GetSkin((int)pantType);
        }
    }
    public virtual Constants.PantsType GetPantsTypeFromString(string pantName)
    {
        if (Enum.TryParse(pantName, true, out Constants.PantsType pantsType))
        {
            return pantsType;
        }

        return Constants.PantsType.Default;
    }

    public virtual void ChangeFullSet(string setType)
    {
        TakeOffSet();

        if (currentHat = SkinSpawner.Instance.SpawnInParent(setType + "Hat", head))
        {
            Debug.Log("Hat");
            currentHat.gameObject.SetActive(true);
        }

        if (currentAccessory = SkinSpawner.Instance.SpawnInParent(setType + "Shield", leftHand))
        {
            Debug.Log("Shield");
            currentAccessory.gameObject.SetActive(true);
        }

        if (currentBack = SkinSpawner.Instance.SpawnInParent(setType + "Back", back))
        {
            Debug.Log("Back");
            currentBack.gameObject.SetActive(true);
        }


        if (currentTail = SkinSpawner.Instance.SpawnInParent(setType + "Tail", tail))
        {
            Debug.Log("Tail");
            currentTail.gameObject.SetActive(true);
        }

        

    }

    protected void DespawnWeapon()
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
            //SkinSpawner.Instance.Despawn(currentWeapon);
        }
    }

    public virtual void TakeOffSet()
    {
        DespawnHat();
        DespawnPants();
        DespawnAccessory();
        DespawnBack();
        DespawnTail();
    }


    protected void DespawnHat()
    {
        if (currentHat)
        {
            Destroy(currentHat.gameObject);
        }
    }

    protected void DespawnAccessory()
    {
        if (currentAccessory)
        {
            Destroy(currentAccessory.gameObject);
        }
    }

    protected void DespawnBack()
    {
        if (currentBack)
        {
            Destroy(currentBack.gameObject);
        }
    }

    protected void DespawnTail()
    {
        if (currentTail)
        {
            Destroy(currentTail.gameObject);
        }
    }

    protected void DespawnPants()
    {
        pants.materials = Array.Empty<Material>();
    }

}
