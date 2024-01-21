using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EnableButtonOnMenu : MonoBehaviour
{
    [SerializeField] private IUserMenu _Menu;
    public void SwitchMode()
    {
        if(!_Menu.isActive)  
        {
            UISystem.EnableMenu(_Menu);
            Debug.Log("Enable");
        }
        else
        {
            UISystem.DisableMenu(_Menu);
            Debug.Log("Disable");
        }
    }
}
