using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponShop : UIBase
{
    [Header("Button")]
    [SerializeField] private GameObject buyButton;
    [SerializeField] private GameObject equipButton;
    [SerializeField] private GameObject equipedButton;

    [Header("Player Data")]
    [SerializeField] protected PlayerSkin playerSkin;
    [SerializeField] protected TextMeshProUGUI playerGold;


    [Header("Weapon Data")]
    [SerializeField] protected WeaponData[] weaponDatas;
    [SerializeField] protected Image weaponImage;
    [SerializeField] protected TextMeshProUGUI weaponPrice;
    [SerializeField] protected TextMeshProUGUI weaponDescription;
    private int currentWeaponIndex;

    public virtual void OnEnable()
    {
        playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
        currentWeaponIndex = 0;
    }

    public virtual void OnDisable() 
    {
        CharacterData.Instance.SetData();
        
    }

    public virtual void ChangeWeaponUI(int index)
    {
        currentWeaponIndex += index;
        if (currentWeaponIndex > 2)
        {
            currentWeaponIndex = 0;
        }
        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = 2;
        }
        switch (currentWeaponIndex)
        {
            case 0:
                playerSkin.ChangeWeapon(weaponDatas[currentWeaponIndex].name);
                ShowWeaponOnUI(currentWeaponIndex);
                ShowWeaponState(currentWeaponIndex);
                SetWeaponDescription(currentWeaponIndex);
                break;
            case 1:
                playerSkin.ChangeWeapon(weaponDatas[currentWeaponIndex].name);
                ShowWeaponOnUI(currentWeaponIndex);
                ShowWeaponState(currentWeaponIndex);
                SetWeaponDescription(currentWeaponIndex);
                break;
            case 2:
                playerSkin.ChangeWeapon(weaponDatas[currentWeaponIndex].name);
                ShowWeaponOnUI(currentWeaponIndex);
                ShowWeaponState(currentWeaponIndex);
                SetWeaponDescription(currentWeaponIndex);
                break;
        }
    }

    protected virtual void SetWeaponDescription(int currentWeaponIndex)
    {
        weaponDescription.text = weaponDatas[currentWeaponIndex].attackSpeed + " Speed, " + weaponDatas[currentWeaponIndex].range + " Range";
    }

    public virtual void ShowWeaponOnUI(int currentWeaponIndex)
    {
        if (weaponImage != null)
        {
            weaponImage.sprite = weaponDatas[currentWeaponIndex].icon;
            weaponPrice.text = weaponDatas[currentWeaponIndex].price.ToString();
        }
    }

    public virtual void BuyWeapon()
    {
        int playerGoldInt = CharacterData.Instance.GetPlayerGold();
        switch (currentWeaponIndex)
        {
            case 0:
                if (playerGoldInt >= weaponDatas[currentWeaponIndex].price)
                {
                    playerGoldInt -= weaponDatas[currentWeaponIndex].price;
                    CharacterData.Instance.SavePlayerGold(playerGoldInt);
                    CharacterData.Instance.SaveBuyWeapon(Constants.WeaponType.Knife);
                    playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
                    ShowWeaponState(currentWeaponIndex);
                }
                break;
            case 1:
                if (playerGoldInt >= weaponDatas[currentWeaponIndex].price)
                {
                    playerGoldInt -= weaponDatas[currentWeaponIndex].price;
                    CharacterData.Instance.SavePlayerGold(playerGoldInt);
                    CharacterData.Instance.SaveBuyWeapon(Constants.WeaponType.Hammer);
                    playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
                    ShowWeaponState(currentWeaponIndex);
                }

                break;
            case 2:
                if (playerGoldInt >= weaponDatas[currentWeaponIndex].price)
                {
                    playerGoldInt -= weaponDatas[currentWeaponIndex].price;
                    CharacterData.Instance.SavePlayerGold(playerGoldInt);
                    CharacterData.Instance.SaveBuyWeapon(Constants.WeaponType.Bommerang);
                    playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
                    ShowWeaponState(currentWeaponIndex);
                }

                break;
        }
    }

    public virtual void EquipCharacterWeapon()
    {
        switch (currentWeaponIndex)
        {
            case 0:
                playerSkin.ChangeWeapon(Constants.WeaponType.Knife.ToString());
                CharacterData.Instance.EquipWeapon(Constants.WeaponType.Knife);
                ShowWeaponState(currentWeaponIndex);
                break;
            case 1:
                playerSkin.ChangeWeapon(Constants.WeaponType.Hammer.ToString());
                CharacterData.Instance.EquipWeapon(Constants.WeaponType.Hammer);
                ShowWeaponState(currentWeaponIndex);
                break;
            case 2:
                playerSkin.ChangeWeapon(Constants.WeaponType.Bommerang.ToString());
                CharacterData.Instance.EquipWeapon(Constants.WeaponType.Bommerang);
                ShowWeaponState(currentWeaponIndex);
                break;
        }
    }

    public virtual void ShowWeaponState(int currentWeaponIndex)
    {
        int buyState;
        switch (currentWeaponIndex)
        {
            case 0:
                if (CharacterData.Instance.GetPlayerEquipedWeapon().Equals(Constants.WeaponType.Knife.ToString()))
                {
                    buyButton.SetActive(false);
                    equipButton.SetActive(false);
                    equipedButton.SetActive(true);
                }
                else
                {
                    buyState = CharacterData.Instance.GetWeaponBuyState(Constants.WeaponType.Knife);
                    ShowButtonState(buyState);
                }
                break;
            case 1:
                if (CharacterData.Instance.GetPlayerEquipedWeapon().Equals(Constants.WeaponType.Hammer.ToString()))
                {
                    buyButton.SetActive(false);
                    equipButton.SetActive(false);
                    equipedButton.SetActive(true);
                }
                else
                {
                    buyState = CharacterData.Instance.GetWeaponBuyState(Constants.WeaponType.Hammer);
                    ShowButtonState(buyState);
                }
                break;
            case 2:
                if (CharacterData.Instance.GetPlayerEquipedWeapon().Equals(Constants.WeaponType.Bommerang.ToString()))
                {
                    buyButton.SetActive(false);
                    equipButton.SetActive(false);
                    equipedButton.SetActive(true);
                }
                else
                {
                    buyState = CharacterData.Instance.GetWeaponBuyState(Constants.WeaponType.Bommerang);
                    ShowButtonState(buyState);
                }
                break;
        }
    }

    public virtual void ShowButtonState(int buyState)
    {
        switch (buyState)
        {
            case 0:
                buyButton.SetActive(true);
                equipButton.SetActive(false);
                equipedButton.SetActive(false);
                break;

            case 1:
                buyButton.SetActive(false);
                equipButton.SetActive(true);
                equipedButton.SetActive(false);
                break;
        }
    }
}
