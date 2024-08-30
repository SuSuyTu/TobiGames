using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISkinShop : UIBase
{
    [Header("Player Data")]
    [SerializeField] protected PlayerSkin playerSkin;
    [SerializeField] protected TextMeshProUGUI playerGold;

    [Header("Button")]
    [SerializeField] protected GameObject buyHatButton;
    [SerializeField] protected GameObject buyPantButton;
    [SerializeField] protected GameObject buyAccessoryButton;
    [SerializeField] protected GameObject buyFullSetButton;


    [SerializeField] protected GameObject equipHatButton;
    [SerializeField] protected GameObject equipPantButton;
    [SerializeField] protected GameObject equipAccessoryButton;
    [SerializeField] protected GameObject equipFullSetButton;

    [SerializeField] protected GameObject equipedButton;

    [Header("Price")]
    [SerializeField] protected TextMeshProUGUI hatPriceText;
    [SerializeField] protected TextMeshProUGUI accessoryPriceText;
    [SerializeField] protected TextMeshProUGUI pantPriceText;
    [SerializeField] protected TextMeshProUGUI fullSetPriceText;

    [Header("Skin Data")]
    [SerializeField] protected HatDataSO[] hats;
    [SerializeField] protected AccessoryDataSO[] accessories;
    [SerializeField] protected PantDataSO[] pants;
    [SerializeField] protected SkinSetDataSO[] fullSets;

    private int currentIndex;
    public virtual void OnEnable()
    {
        playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
    }

    public virtual void OnDisable() 
    {
        CharacterData.Instance.SetData();
    }

    public virtual void SetButtonActive(bool state)
    {
        buyHatButton.SetActive(state);
        buyAccessoryButton.SetActive(state);
        buyPantButton.SetActive(state);
        buyFullSetButton.SetActive(state);

        equipAccessoryButton.SetActive(state);
        equipHatButton.SetActive(state);
        equipPantButton.SetActive(state);
        equipFullSetButton.SetActive(state);

        equipedButton.SetActive(state);
    }

    // Hat
    public virtual void BuyHat()
    {
        int playerGoldInt = CharacterData.Instance.GetPlayerGold();
        if (playerGoldInt >= hats[currentIndex].price)
        {
            playerGoldInt -= hats[currentIndex].price;
            CharacterData.Instance.SavePlayerGold(playerGoldInt);
            CharacterData.Instance.SaveBuyHat(hats[currentIndex].hatType);
            playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
            ShowHatState(hats[currentIndex].hatType);
        }
    }

    public virtual void EquipHat()
    {
        playerSkin.ChangeHat(hats[currentIndex].hatType.ToString());
        CharacterData.Instance.SaveEquipedHat(hats[currentIndex].hatType);
        ShowHatState(hats[currentIndex].hatType);
    }

    public virtual void ChangePlayerHat(int index)
    {
        currentIndex = index;
        hatPriceText.text = hats[index].price.ToString();
        switch (index)
        {
            case 0:
                playerSkin.ChangeHat(Constants.HatType.Arrow.ToString());
                ShowHatState(Constants.HatType.Arrow);
                break;
            case 1:
                playerSkin.ChangeHat(Constants.HatType.Crown.ToString());
                ShowHatState(Constants.HatType.Crown);
                break;
            case 2:
                playerSkin.ChangeHat(Constants.HatType.Ear.ToString());
                ShowHatState(Constants.HatType.Ear);
                break;
            case 3:
                playerSkin.ChangeHat(Constants.HatType.Flower.ToString());
                ShowHatState(Constants.HatType.Flower);
                break;
            case 4:
                playerSkin.ChangeHat(Constants.HatType.Hair.ToString());
                ShowHatState(Constants.HatType.Hair);
                break;
            case 5:
                playerSkin.ChangeHat(Constants.HatType.Hat.ToString());
                ShowHatState(Constants.HatType.Hat);
                break;
            case 6:
                playerSkin.ChangeHat(Constants.HatType.Police.ToString());
                ShowHatState(Constants.HatType.Police);
                break;
            case 7:
                playerSkin.ChangeHat(Constants.HatType.Horn.ToString());
                ShowHatState(Constants.HatType.Horn);
                break;
            case 8:
                playerSkin.ChangeHat(Constants.HatType.Rau.ToString());
                ShowHatState(Constants.HatType.Rau);
                break;
        }
    }

    public void ShowHatState(Constants.HatType hatType)
    {
        SetButtonActive(false);
        if (CharacterData.Instance.GetPlayerEquipedHat().Equals(hatType.ToString()))
        {
            buyHatButton.SetActive(false);

            equipHatButton.SetActive(false);

            equipedButton.SetActive(true);
        }
        else
        {
            int state = CharacterData.Instance.GetHatBuyState(hatType);
            switch (state)
            {
                case 0:
                    buyHatButton.SetActive(true);

                    equipHatButton.SetActive(false);

                    equipedButton.SetActive(false);
                    break;
                case 1:
                    buyHatButton.SetActive(false);

                    equipHatButton.SetActive(true);

                    equipedButton.SetActive(false);
                    break;
            }
        }
    }

    public virtual void GetHatButton(Button button)
    {
        button.transform.GetChild(0).gameObject.SetActive(false);
    }



    // Pant

    public virtual void BuyPant()
    {
        int playerGoldInt = CharacterData.Instance.GetPlayerGold();
        if (playerGoldInt >= pants[currentIndex].price)
        {
            playerGoldInt -= pants[currentIndex].price;
            CharacterData.Instance.SavePlayerGold(playerGoldInt);
            CharacterData.Instance.SaveBuyPant(pants[currentIndex].pantType);
            playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
            ShowPantState(pants[currentIndex].pantType);
        }
    }

    public virtual void EquipPant()
    {
        playerSkin.ChangePants(pants[currentIndex].pantType);
        CharacterData.Instance.SaveEquipedPant(pants[currentIndex].pantType);
        ShowPantState(pants[currentIndex].pantType);
    }

    public void ShowPantState(Constants.PantsType pantsType)
    {
        SetButtonActive(false);
        if (CharacterData.Instance.GetPlayerEquipedPant().Equals(pantsType.ToString()))
        {
            buyPantButton.SetActive(false);

            equipPantButton.SetActive(false);

            equipedButton.SetActive(true);
        }
        else
        {
            int state = CharacterData.Instance.GetPantBuyState(pantsType);
            switch (state)
            {
                case 0:
                    buyPantButton.SetActive(true);

                    equipPantButton.SetActive(false);

                    equipedButton.SetActive(false);
                    break;
                case 1:
                    buyPantButton.SetActive(false);

                    equipPantButton.SetActive(true);

                    equipedButton.SetActive(false);
                    break;
            }
        }
    }

    public virtual void ChangePlayerPant(int index)
    {
        currentIndex = index;
        pantPriceText.text = pants[index].price.ToString();
        switch (index)
        {
            case 0:
                playerSkin.ChangePants(Constants.PantsType.batman);
                ShowPantState(Constants.PantsType.batman);
                break;
            case 1:
                playerSkin.ChangePants(Constants.PantsType.chambi);
                ShowPantState(Constants.PantsType.chambi);
                break;
            case 2:
                playerSkin.ChangePants(Constants.PantsType.comy);
                ShowPantState(Constants.PantsType.comy);
                break;
            case 3:
                playerSkin.ChangePants(Constants.PantsType.dabao);
                ShowPantState(Constants.PantsType.dabao);
                break;
            case 4:
                playerSkin.ChangePants(Constants.PantsType.onion);
                ShowPantState(Constants.PantsType.onion);
                break;
            case 5:
                playerSkin.ChangePants(Constants.PantsType.pokemon);
                ShowPantState(Constants.PantsType.pokemon);
                break;
            case 6:
                playerSkin.ChangePants(Constants.PantsType.rainbow);
                ShowPantState(Constants.PantsType.rainbow);
                break;
            case 7:
                playerSkin.ChangePants(Constants.PantsType.skull);
                ShowPantState(Constants.PantsType.skull);
                break;
            case 8:
                playerSkin.ChangePants(Constants.PantsType.vantim);
                ShowPantState(Constants.PantsType.vantim);
                break;
        }
    }

    // Accessory
    public virtual void BuyAccessory()
    {
        int playerGoldInt = CharacterData.Instance.GetPlayerGold();
        if (playerGoldInt >= accessories[currentIndex].price)
        {
            playerGoldInt -= accessories[currentIndex].price;
            CharacterData.Instance.SavePlayerGold(playerGoldInt);
            CharacterData.Instance.SaveBuyAccessory(accessories[currentIndex].accessoryType);
            playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
            ShowAccessoryState(accessories[currentIndex].accessoryType);
        }
    }

    public virtual void EquipAccessory()
    {
        playerSkin.ChangeAccessory(accessories[currentIndex].accessoryType.ToString());
        CharacterData.Instance.SaveEquipedAccessory(accessories[currentIndex].accessoryType);
        ShowAccessoryState(accessories[currentIndex].accessoryType);
    }

    public void ShowAccessoryState(Constants.AccessoryType accessoryType)
    {
        SetButtonActive(false);
        if (CharacterData.Instance.GetPlayerEquipedAccessory().Equals(accessoryType.ToString()))
        {
            buyAccessoryButton.SetActive(false);

            equipAccessoryButton.SetActive(false);

            equipedButton.SetActive(true);
        }
        else
        {
            int state = CharacterData.Instance.GetAccessoryBuyState(accessoryType);
            switch (state)
            {
                case 0:
                    buyAccessoryButton.SetActive(true);

                    equipAccessoryButton.SetActive(false);

                    equipedButton.SetActive(false);
                    break;
                case 1:
                    buyAccessoryButton.SetActive(false);

                    equipAccessoryButton.SetActive(true);

                    equipedButton.SetActive(false);
                    break;
            }
        }
    }

    public virtual void ChangePlayerAccessory(int index)
    {
        currentIndex = index;
        accessoryPriceText.text = accessories[index].price.ToString();
        switch (index)
        {
            case 0:
                playerSkin.ChangeAccessory(Constants.AccessoryType.CaptainShield.ToString());
                ShowAccessoryState(Constants.AccessoryType.CaptainShield);
                break;
            case 1:
                playerSkin.ChangeAccessory(Constants.AccessoryType.BatmanShield.ToString());
                ShowAccessoryState(Constants.AccessoryType.BatmanShield);
                break;
        }
    }


    // Full Set
    
    public virtual void BuyFullSet()
    {
        int playerGoldInt = CharacterData.Instance.GetPlayerGold();
        if (playerGoldInt >= fullSets[currentIndex].price)
        {
            playerGoldInt -= fullSets[currentIndex].price;
            CharacterData.Instance.SavePlayerGold(playerGoldInt);
            CharacterData.Instance.SaveBuyFullSet(fullSets[currentIndex].setType);
            playerGold.text = CharacterData.Instance.GetPlayerGold().ToString();
            ShowFullSetState(fullSets[currentIndex].setType);
        }
    }

    public virtual void EquipFullSet()
    {
        playerSkin.ChangeFullSet(fullSets[currentIndex].setType.ToString());
        CharacterData.Instance.SaveBuyFullSet(fullSets[currentIndex].setType);
        ShowFullSetState(fullSets[currentIndex].setType);
    }

    public void ShowFullSetState(Constants.SetType setType)
    {
        SetButtonActive(false);
        if (CharacterData.Instance.GetPlayerEquipedFullSet().Equals(setType.ToString()))
        {
            buyFullSetButton.SetActive(false);

            equipFullSetButton.SetActive(false);

            equipedButton.SetActive(true);
        }
        else
        {
            int state = CharacterData.Instance.GetFullSetBuyState(setType);
            switch (state)
            {
                case 0:
                    buyFullSetButton.SetActive(true);

                    equipFullSetButton.SetActive(false);

                    equipedButton.SetActive(false);
                    break;
                case 1:
                    buyFullSetButton.SetActive(false);

                    equipFullSetButton.SetActive(true);

                    equipedButton.SetActive(false);
                    break;
            }
        }
    }
    public void ChangePlayerFullSet(int index)
    {
        currentIndex = index;
        fullSetPriceText.text = fullSets[index].price.ToString();
        switch (index)
        {
            case 0:
                playerSkin.ChangeFullSet(Constants.SetType.Devil.ToString());
                ShowFullSetState(Constants.SetType.Devil);
                playerSkin.ChangeSkinColor(fullSets[currentIndex].Skin);
                break;
            case 1:
                playerSkin.ChangeFullSet(Constants.SetType.Angel.ToString());
                ShowFullSetState(Constants.SetType.Angel);
                playerSkin.ChangeSkinColor(fullSets[currentIndex].Skin);
                break;
            case 2:
                playerSkin.ChangeFullSet(Constants.SetType.Witch.ToString());
                ShowFullSetState(Constants.SetType.Witch);
                playerSkin.ChangeSkinColor(fullSets[currentIndex].Skin);
                break;
            case 3:
                playerSkin.ChangeFullSet(Constants.SetType.Deadpool.ToString());
                ShowFullSetState(Constants.SetType.Deadpool);
                playerSkin.ChangeSkinColor(fullSets[currentIndex].Skin);
                break;
            case 4:
                playerSkin.ChangeFullSet(Constants.SetType.Thor.ToString());
                ShowFullSetState(Constants.SetType.Thor);
                playerSkin.ChangeSkinColor(fullSets[currentIndex].Skin);
                break;
        }
    }

}
