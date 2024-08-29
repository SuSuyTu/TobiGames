using UnityEngine;

public class UIBase : MonoBehaviour
{
    public bool IsDestroyOnClose = false;

    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    public virtual void CloseDirectly()
    {
        gameObject.SetActive(false);
        if (IsDestroyOnClose)
        {
            Destroy(gameObject);
        }
        
    }

    public virtual void Close(float delayTime)
    {
        Invoke(nameof(CloseDirectly), delayTime);
    }

}
