using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
public class UILose : UIBase
{
    [SerializeField] protected TextMeshProUGUI muderName; 

    [SerializeField] protected TextMeshProUGUI rankText;
    public virtual void OnContrinue()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Instance.SwitchState(GameState.MainMenu);
    }
}
