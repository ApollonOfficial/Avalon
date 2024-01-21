using System;
using UnityEngine;
using NaughtyAttributes;

public class InventorySystem : MonoBehaviour
{
    public static event Action<ItemData,int> AddItem;
    public static event Action<InventorySlot> RemoveItem;

    public static event Action<Stats> EnableArtifact;
    public static event Action<Stats> DisableArtifact;

    public GameData GameData;

    private GameObject _lastItem;

    private void DestroyAddedItem()
    {
        Destroy(_lastItem);
    }
    private void ClearDontAddItem()
    {
        _lastItem = null;
    }
    private void OnEnable()
    {
        Inventory.ItemAdded += DestroyAddedItem;
        Inventory.ItemDontAdd += ClearDontAddItem;
    }
    private void OnDisable()
    {
        Inventory.ItemAdded -= DestroyAddedItem;
        Inventory.ItemDontAdd -= ClearDontAddItem;
    }

    [Button] public void AddItemOnInventory()
    {
        AddItem?.Invoke(GameData.ItemsList[0], 1);
    }
}
