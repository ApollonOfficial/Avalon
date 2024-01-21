using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IUserMenu
{
    public static event Action ItemAdded;
    public static event Action ItemDontAdd;
    public static event Action SlotEdit;

    [SerializeField] private InventorySlot _SlotPrefab;
    [SerializeField] private Transform _Inventory;
    private List<InventorySlot> _slots = new List<InventorySlot>();

    private void Awake()
    {
        for(int i = 0; i < 18; i++)
        {
            _slots.Add(Instantiate(_SlotPrefab, _Inventory));
        }
        InventorySystem.AddItem += AddItem;
        InventorySystem.RemoveItem += RemoveItem;
    }

    private void  OnDestroy()
    {
        InventorySystem.AddItem -= AddItem;
        InventorySystem.RemoveItem -= RemoveItem;
    }

    private void AddItem(ItemData item, int count)
    {
        foreach(InventorySlot slot in _slots)
        {
            if(slot.IsEmpty)
            {
                slot.SlotData.Set(new SlotData(item, count));
                ItemAdded?.Invoke();
                SlotEdit?.Invoke();
                return;
            }
        }
        ItemDontAdd?.Invoke();
    }
    private void RemoveItem(InventorySlot inventorySlot)
    {
        inventorySlot.SlotData.Set(null);
        SlotEdit?.Invoke();
    }

    public override void EnableMenu()
    {
        gameObject.SetActive(true);
        SlotEdit?.Invoke();
    }

    public override void DisableMenu()
    {
        gameObject.SetActive(false);
    }
}
