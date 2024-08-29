using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField] protected List<UIBase> canvasList;
    public List<UIBase> CanvasList => canvasList;

    [SerializeField] protected FloatingJoystick floatingJoystick;
    public FloatingJoystick FloatingJoystick => floatingJoystick;

    public TextMeshProUGUI murderName;
    public TextMeshProUGUI rankText;
    

    protected virtual void Awake()
    {
        if (UIManager.instance != null) Debug.Log("Only 1 UIManagaer allow to exist");
        UIManager.instance = this;
    }

    public virtual void CloseAll()
    {
        foreach (UIBase canvas in canvasList)
        {
            Debug.Log(canvas.gameObject.name);
            canvas.gameObject.SetActive(false);
        }
    }

    public virtual void OpenMainMenuCanvas()
    {
        CloseAll();
        foreach (UIBase canvas in canvasList)
        {
            if (canvas is UIMainMenu)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }

    public virtual void OpenSkinCanvas()
    {
        foreach (UIBase canvas in canvasList)
        {
            if (canvas is UISkinShop)
            {
                canvas.gameObject.SetActive(true);
            }
        }
        PlayerCtrl.Instance.Animator.SetBool("IsDance", true);
    }

    public virtual void OpenWeaponCanvas()
    {
        foreach (UIBase canvas in canvasList)
        {
            if (canvas is UIWeaponShop)
            {
                canvas.gameObject.SetActive(true);
            }
        }
        PlayerCtrl.Instance.Animator.SetBool("IsDance", true);
    }

    public virtual void OpenLoseCanvas()
    {
        CloseAll();
        foreach (UIBase canvas in canvasList)
        {
            if (canvas is UILose)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }

    public virtual void OpenVictoryCanvas()
    {
        CloseAll();
        foreach (UIBase canvas in canvasList)
        {
            if (canvas is UIVictory)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }

    public virtual void OpenSettingCanvas()
    {
        foreach (UIBase canvas in canvasList)
        {
            if (canvas is UISettings)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }

    public virtual void OpenReviveCanvas()
    {
        foreach (UIBase canvas in canvasList)
        {
            if (canvas is UIReive)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }

    public virtual void OnPlay()
    {
        GameManager.Instance.SwitchState(GameState.Tutorial);
        //CharacterData.Instance.SetData();
    }

    public virtual void SetMurderName(String name)
    {
        murderName.text = name;
    }

    public virtual void SetRankText(String rank)
    {
        rankText.text = "#" + rank;
    }

}
