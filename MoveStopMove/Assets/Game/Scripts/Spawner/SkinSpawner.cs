using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSpawner : Spawner
{
    private static SkinSpawner instance;
    public static SkinSpawner Instance { get => instance; }
    protected virtual void Awake()
    {
        if (SkinSpawner.instance != null) Debug.LogError("Only 1 SkinSpawner allow to exist");
        SkinSpawner.instance = this;
    }

    public string GetWeaponName(Constants.WeaponType weapon)
    {
        switch (weapon)
        {
            case Constants.WeaponType.Hammer:
                return "Hammer";
            case Constants.WeaponType.Bommerang:
                return "Bommerang";
            case Constants.WeaponType.Knife:
                return "Knife";
            default:
                return "Unknown Weapon";
        }
    }
}
