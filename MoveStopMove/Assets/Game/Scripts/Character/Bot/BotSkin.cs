using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSkin : CharacterSkin
{
    [SerializeField] protected BotCtrl botCtrl;
    [SerializeField] private CharacterSkinDataSO characterSkinData;
    private List<Material> assignedSkin;
    public override void ChangeSkin()
    {
        //string wepName = GetRandomWeapon().ToString();
        //Debug.Log(wepName);
        //ChangeWeapon(wepName);
        ChangeWeapon(GetRandomWeapon());
        //ChangeWeapon(Constants.WeaponType.Knife.ToString());

        //(GetRandomWeapon().ToString());
        //ChangeWeapon(Utilities.RandomEnumValue<WeaponType>());
        ChangeAccessory(GetRandomAccessory());
        ChangeHat(GetRandomHatType());
        ChangePants(GetRandomPants());
        ChangeSkinColor(GetRandomSkin());
    }

    public string GetRandomWeapon()
    {
        Constants.WeaponType[] weaponTypes = (Constants.WeaponType[])System.Enum.GetValues(typeof(Constants.WeaponType));

        int randomIndex = Random.Range(0, weaponTypes.Length); 

        Debug.Log(weaponTypes[randomIndex].ToString());


        return weaponTypes[randomIndex].ToString();
    }

    public Constants.SkinColorType GetRandomSkinColor()
    {
        Constants.SkinColorType[] skinColorTypes = (Constants.SkinColorType[])System.Enum.GetValues(typeof(Constants.SkinColorType));

        int randomIndex = Random.Range(0, skinColorTypes.Length - 1); 

        return skinColorTypes[randomIndex];
    }

    public string GetRandomHatType()
    {
        Constants.HatType[] hatTypes = (Constants.HatType[])System.Enum.GetValues(typeof(Constants.HatType));

        int randomIndex = Random.Range(0, hatTypes.Length - 1); 
        //Debug.Log(hatTypes[randomIndex].ToString());

        return hatTypes[randomIndex].ToString();
    }

    public string GetRandomAccessory()
    {
        Constants.AccessoryType[] accessoryTypes = (Constants.AccessoryType[])System.Enum.GetValues(typeof(Constants.AccessoryType));

        int randomIndex = Random.Range(0, accessoryTypes.Length - 1); 
        //Debug.Log(accessoryTypes[randomIndex].ToString());

        return accessoryTypes[randomIndex].ToString();
    }

    public Constants.PantsType GetRandomPants()
    {
        Constants.PantsType[] pantsTypes = (Constants.PantsType[])System.Enum.GetValues(typeof(Constants.PantsType));

        int randomIndex = Random.Range(0, pantsTypes.Length - 1); 

        return pantsTypes[randomIndex];
    }

    private Material GetRandomSkin()
    {
        if (assignedSkin == null)
            assignedSkin = new List<Material>();
        
        int randomIndex = UnityEngine.Random.Range(0, characterSkinData.skinColor.Count);
        Material randomSkin = characterSkinData.skinColor[randomIndex];
        assignedSkin.Add(randomSkin);
        return randomSkin;
    }
}
