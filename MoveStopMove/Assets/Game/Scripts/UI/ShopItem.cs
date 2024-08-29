using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public enum State
    {
        Lock = Constants.ButtonState.Lock,
        Unlock = Constants.ButtonState.Unlock
    }
    //public enum State {Lock = 0, Unlock = 1}

    [SerializeField] protected Image imgIcon;

    public State CurrentState { get; private set; }
    public Constants.ItemType Type { get; private set; }
    public Enum ID { get; private set; }
    public int Cost { get; private set; }

    protected CharacterData characterData => CharacterData.Instance;



    public void OnInit<T>(Constants.ItemType type, ItemData<T> itemData, State state) where T : Enum
    {
        Type = type;
        ID = itemData.Id;
        Cost = itemData.Cost;
        imgIcon.sprite = itemData.Sprite;
        CurrentState = state;

        SetState(state);
    }

    public void SetState(State state)
    {
        CurrentState = state;
        //playerSkin.SetItemState(Type, ID, (int)state);
    }
}

