using System;
using UnityEngine;

public class ItemData<T> where T : Enum
    {
        [SerializeField] private T id;
        [SerializeField] private int cost;
        [SerializeField] private Sprite sprite;

        public T Id => id;
        public int Cost => cost;
        public Sprite Sprite => sprite;
    }
