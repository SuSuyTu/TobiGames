using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuManager : NewMonoBehaviour
{
    public virtual void OnClickPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public virtual void OnClickQuitButton()
    {
        Application.Quit();
    }
}
