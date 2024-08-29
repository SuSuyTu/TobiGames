using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFade : MonoBehaviour
{
    [SerializeField]
    private Renderer _renderer;
    private Material material;
    private Color fadeColor;
    private bool isFade;
    void Start()
    {
        isFade = false;
        material = _renderer.material;
        fadeColor = material.color;
    }

    void Update()
    {
        if (isFade)
        {
            MaterialObstacleFade.MakeFade(material);
            fadeColor.a = 0.5f;
        }
        else
        {
            MaterialObstacleFade.MakeOpaque(material);
            fadeColor.a = 1f;
        }

        material.color = fadeColor;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerCtrl player = Cache<PlayerCtrl>.GetComponent(other);
        if (player != null)
        {
            isFade = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerCtrl player = Cache<PlayerCtrl>.GetComponent(other);
        if (player != null)
        {
            isFade = false;
        }
    }
}
