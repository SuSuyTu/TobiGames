using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMainMenu : UIBase
{
    [SerializeField] private TextMeshProUGUI coin;
    private CharacterSkin playerSkin => PlayerCtrl.Instance.CharacterSkin;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private TMP_InputField playerName;

    // public virtual void SetPlayerName()
    // {
    //     PlayerCtrl.Instance.characterName = playerName.text;
    // }
    protected virtual void OnEnable()
    {
        playerName.text = CharacterData.Instance.GetPlayerName();
        coin.text = CharacterData.Instance.GetPlayerGold().ToString();
    }

    protected virtual void OnDisable()
    {
        PlayerCtrl.Instance.characterName = playerName.text;
        CharacterData.Instance.SavePlayerName(playerName.text);
    }
   
    public virtual void TurnSoundOff()
    {
        soundManager.gameObject.SetActive(false);
    }
    public virtual void TurnSoundOn()
    {
        soundManager.gameObject.SetActive(true);
    }
}
