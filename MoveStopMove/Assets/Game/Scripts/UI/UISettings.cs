using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISettings : UIBase
{
    public virtual void OnRestart()
    {
        GameManager.Instance.SwitchState(GameState.Tutorial);
    }

    public virtual void OnHome()
    {
        GameManager.Instance.SwitchState(GameState.MainMenu);
    }
}
