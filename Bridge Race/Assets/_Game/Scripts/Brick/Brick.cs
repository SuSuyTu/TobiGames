using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : NewMonoBehaviour
{
    [SerializeField] protected Color color;
    public Color Color => color;
    public virtual void SetColor(Color color)
    {
        this.color = color;
    }

    // protected override void Reset()
    // {
    //     base.Reset();
    //     LoadBrickColor();
    // }

    // protected virtual void LoadBrickColor()
    // {
    //     if (this.brickColor != null) return;
    //     this.brickColor = GetComponent<MeshRenderer>().materia;
    //     Debug.LogWarning(transform.name + ": LoadBrickColor", gameObject);
    // }
}
