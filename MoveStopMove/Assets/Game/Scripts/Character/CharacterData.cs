using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    private static CharacterData instance;
    public static CharacterData Instance => instance;

    protected virtual void Awake()
    {
        if (CharacterData.instance != null) Debug.LogWarning("Only 1 CharacterData allow to exist");
        CharacterData.instance = this;
    }

    public virtual void SetData()
    {
        PlayerCtrl.Instance.characterName = PlayerPrefs.GetString(Constants.PlayerPrefsKey.PlayerName.ToString(), "Player");
        PlayerCtrl.Instance.CharacterSkin.ChangeWeapon(GetPlayerEquipedWeapon());
        PlayerCtrl.Instance.CharacterSkin.ChangeHat(GetPlayerEquipedHat());
        PlayerCtrl.Instance.CharacterSkin.ChangeAccessory(GetPlayerEquipedAccessory());
        PlayerCtrl.Instance.CharacterSkin.ChangePants(PlayerCtrl.Instance.CharacterSkin.GetPantsTypeFromString(GetPlayerEquipedPant()));
        //PlayerCtrl.Instance.CharacterSkin.ChangeFullSet(GetPlayerEquipedFullSet());
    }


    // Player Name and Gold
    public virtual void SavePlayerName(String playerName)
    {
        PlayerPrefs.SetString(Constants.PlayerPrefsKey.PlayerName.ToString(), playerName);
        PlayerPrefs.Save();
    }

    public virtual string GetPlayerName()
    {
        return PlayerPrefs.GetString(Constants.PlayerPrefsKey.PlayerName.ToString());
    }

    public virtual void SavePlayerGold(int toatalGold)
    {
        PlayerPrefs.SetInt(Constants.PlayerPrefsKey.PlayerGold.ToString(), toatalGold);
        PlayerPrefs.Save();
    }

    public virtual int GetPlayerGold()
    {
        return PlayerPrefs.GetInt(Constants.PlayerPrefsKey.PlayerGold.ToString(), 1000);
    }



    // UI Skin Shop

    // Hat
    public virtual void SaveEquipedHat(Constants.HatType hatType)
    {
        PlayerPrefs.SetString(Constants.PlayerPrefsKey.Hat.ToString(), hatType.ToString());
        PlayerPrefs.Save();
    }

    public virtual void SaveBuyHat(Constants.HatType hatType)
    {
        PlayerPrefs.SetInt(hatType.ToString(), 1);
        PlayerPrefs.Save();
    }

    public virtual string GetPlayerEquipedHat()
    {
        return PlayerPrefs.GetString(Constants.PlayerPrefsKey.Hat.ToString());
    }

    public virtual int GetHatBuyState(Constants.HatType hatType)
    {
        return PlayerPrefs.GetInt(hatType.ToString(), 0);
    }


    // Accessory
    public virtual void SaveEquipedAccessory(Constants.AccessoryType accessoryType)
    {
        PlayerPrefs.SetString(Constants.PlayerPrefsKey.Accessory.ToString(), accessoryType.ToString());
        PlayerPrefs.Save();
    }

    public virtual string GetPlayerEquipedAccessory()
    {
        return PlayerPrefs.GetString(Constants.PlayerPrefsKey.Accessory.ToString());
    }

    public virtual void SaveBuyAccessory(Constants.AccessoryType accessoryType)
    {
        PlayerPrefs.SetInt(accessoryType.ToString(), 1);
        PlayerPrefs.Save();
    }

    public virtual int GetAccessoryBuyState(Constants.AccessoryType accessoryType)
    {
        return PlayerPrefs.GetInt(accessoryType.ToString(), 0);
    }

    // Pant
    public virtual void SaveEquipedPant(Constants.PantsType pantsType)
    {
        PlayerPrefs.SetString(Constants.PlayerPrefsKey.Pant.ToString(), pantsType.ToString());
        PlayerPrefs.Save();
    }

    public virtual void SaveBuyPant(Constants.PantsType pantsType)
    {
        PlayerPrefs.SetInt(pantsType.ToString(), 1);
        PlayerPrefs.Save();
    }

    public virtual string GetPlayerEquipedPant()
    {
        return PlayerPrefs.GetString(Constants.PlayerPrefsKey.Pant.ToString());
    }

    public virtual int GetPantBuyState(Constants.PantsType pantsType)
    {
        return PlayerPrefs.GetInt(pantsType.ToString(), 0);
    }


    // FullSet

    public virtual void SaveEquipedFullSet(Constants.SetType fullSetType)
    {
        PlayerPrefs.SetString(Constants.PlayerPrefsKey.FullSet.ToString(), fullSetType.ToString());
        PlayerPrefs.Save();
    }

    public virtual void SaveBuyFullSet(Constants.SetType fullSetType)
    {
        PlayerPrefs.SetInt(fullSetType.ToString(), 1);
        PlayerPrefs.Save();
    }

    public virtual string GetPlayerEquipedFullSet()
    {
        return PlayerPrefs.GetString(Constants.PlayerPrefsKey.FullSet.ToString());
    }

    public virtual int GetFullSetBuyState(Constants.SetType fullSetType)
    {
        return PlayerPrefs.GetInt(fullSetType.ToString(), 0);
    }

    // UI Weapon Shop
    public virtual void EquipWeapon(Constants.WeaponType weaponType)
    {
        PlayerPrefs.SetString(Constants.PlayerPrefsKey.Weapon.ToString(), weaponType.ToString());
        PlayerPrefs.Save();
    }

    public virtual string GetPlayerEquipedWeapon()
    {
        return PlayerPrefs.GetString(Constants.PlayerPrefsKey.Weapon.ToString(), Constants.WeaponType.Knife.ToString());
    }

    public virtual void SaveBuyWeapon(Constants.WeaponType weaponType)
    {
        PlayerPrefs.SetInt(weaponType.ToString(), 1);
        PlayerPrefs.Save();
    }

    public virtual int GetWeaponBuyState(Constants.WeaponType weaponType)
    {
        return PlayerPrefs.GetInt(weaponType.ToString(), 0);
    }
}
