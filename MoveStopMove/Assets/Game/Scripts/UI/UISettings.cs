using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettings : UIBase
{
    public virtual void OnRestart()
    {
        Time.timeScale = 1;
        GameManager.Instance.SwitchState(GameState.Tutorial);
        this.gameObject.SetActive(false);
    }

    public virtual void OnHome()
    {
        Time.timeScale = 1;
        GameManager.Instance.SwitchState(GameState.MainMenu);
        this.gameObject.SetActive(false);
    }
}
