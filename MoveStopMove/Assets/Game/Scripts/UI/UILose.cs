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
        PlayerSpawner.Instance.Prefabs[0].gameObject.SetActive(false);
        PlayerCtrl.Instance.transform.position = Vector3.zero;
        //transform.parent.position =  Vector3.zero;
        GameManager.Instance.SwitchState(GameState.MainMenu);
    }
}
