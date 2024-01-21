using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    private static List<IUserMenu> _MenuList;
    private static IUserMenu _BaseMenu;
    private static IUserMenu _LastMenu;

    [SerializeField] private IUserMenu _baseMenu;

    private void Start()
    {
        _MenuList = GameObject.FindObjectsOfType<IUserMenu>().ToList();
        _BaseMenu = _baseMenu;
        EnableMenu(_baseMenu);
    }
    public static void DisableAllMenu()
    {
        _LastMenu = null;
        foreach(IUserMenu menu in _MenuList)
        {
            if(menu.isActive)
            {
                menu.DisableMenu();
                _LastMenu = menu;
            }
        }
    }

    public static void EnableMenu(IUserMenu menu)
    {
        DisableAllMenu();
        menu.EnableMenu();
    }

    public static void DisableMenu(IUserMenu menu)
    {
        menu.DisableMenu();
        if(_LastMenu)
        {
            _LastMenu.EnableMenu();
        }
        else
        {
            _BaseMenu?.EnableMenu();
        }
        
    }
}
