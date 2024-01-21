[System.Serializable] public class SlotData
{
    public ItemData ItemData;
    public int Count;

    public void Destruct(out ItemData itemData, out int count)
    {
        itemData = ItemData;
        count = Count;
    }

    public SlotData(ItemData itemData, int count)
    {
        ItemData = itemData;
        Count = count;
    }
}
public class InventorySlotData
{
    private SlotData _slotData = new SlotData(null, 0);

    public bool IsEmpty => _slotData.ItemData == null;

    public ItemData GetItem() => _slotData.ItemData;
    public int GetCount() => _slotData.Count;

    public void Set(SlotData slotData) => _slotData = slotData;
    public void Set(SlotData itemData, out SlotData lastItemData)
    {
        lastItemData = _slotData;
        _slotData = itemData;
    }
}
