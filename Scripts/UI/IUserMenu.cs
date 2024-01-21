using System;
using UnityEngine;

public abstract class IUserMenu : MonoBehaviour
{
    //public virtual event Action Enable;
    public bool isActive{get => gameObject.activeSelf;}

    public virtual void EnableMenu()
    {
        gameObject.SetActive(true);
    }
    public virtual void DisableMenu()
    {
        gameObject.SetActive(false);
    }
}
