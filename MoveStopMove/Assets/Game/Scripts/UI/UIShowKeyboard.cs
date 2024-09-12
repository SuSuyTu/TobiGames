using Microsoft.MixedReality.Toolkit.Experimental.UI;
using TMPro;
using UnityEngine;

public class UIShowKeyboard : MonoBehaviour
{
    [SerializeField] protected TMP_InputField playerName;

    protected virtual void Start() 
    {
        playerName.onSelect.AddListener(x => OpenKeyboard());
    }

    protected virtual void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = playerName;
        NonNativeKeyboard.Instance.PresentKeyboard();
    }
}

