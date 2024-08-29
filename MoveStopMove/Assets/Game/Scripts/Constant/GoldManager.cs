using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    private static GoldManager instance;
    public static GoldManager Instance => instance;

    public int playerGold;
    
    protected virtual void Awake()
    {
        if (GoldManager.instance != null) Debug.LogWarning("Only 1 GoldManager allows to exist");
        GoldManager.instance = this;

    }

    protected virtual void Start()
    {
        playerGold = CharacterData.Instance.GetPlayerGold();
    }

    public virtual void GetGoldAfterStage(int point)
    {
        int total = (int) Constants.Gold.GOLD_PER_KILL * point + (int) Constants.Gold.GOLD_PER_LEVEL;
        playerGold += total;
        CharacterData.Instance.SavePlayerGold(playerGold);
    }

    public virtual bool WithDraw(int goldAmount)
    {
        if (playerGold >= goldAmount)
        {
            playerGold -= goldAmount;
            return true;
        }
        return false;
    }


}
