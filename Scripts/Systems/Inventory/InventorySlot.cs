using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _SlotPreviewIcon;
    [SerializeField] private Text _SlotPreviewCount;
    [SerializeField] private Transform _SlotPreviewTransform;

    private InventorySlotData _slotData = new InventorySlotData();

    public Transform SlotPreviewTransform => _SlotPreviewTransform;
    public InventorySlotData SlotData => _slotData;
    public bool IsEmpty => _slotData.IsEmpty;

    private void UpdateSlot()
    {
        if(_slotData.IsEmpty)
        {
            _SlotPreviewTransform.gameObject.SetActive(false);
            return;
        }
        _SlotPreviewTransform.gameObject.SetActive(true);
        _SlotPreviewIcon.sprite = _slotData.GetItem().Base.Icon;
        _SlotPreviewCount.text = _slotData.GetCount().ToString();
    }

    private void Awake()
    {
        Inventory.SlotEdit += UpdateSlot;
    }
    private void OnDestroy()
    {
        Inventory.SlotEdit -= UpdateSlot;
    }
    
}
