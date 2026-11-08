using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;

    // [SerializeField] private GameObject mainInventory;
    // [SerializeField] private GameObject inventoryHotbar;
    [SerializeField] private Transform hotbarPanel;

    private readonly List<InventorySlotUI> slots = new();

    void Start()
    {
        InventoryManager.Instance.OnInventoryChanged += Refresh;

        CreateSlots();
        Refresh();
    }

    private void CreateSlots()
    {
        for (int i = 0; i < 36; i++)
        {
            // Transform parent = i < 9 ? inventoryHotbar : mainInventory

            // GameObject obj = Instantiate(slotPrefab, parent);

            // slots.Add(obj.GetComponent<InventorySlotUI>());
        }

        for (int i = 0; i < 9; i++)
        {
            Instantiate(slotPrefab, hotbarPanel);
        }
    }
    private void Refresh()
    {
        InventorySlot[] inventory = InventoryManager.Instance.Slots;

        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].SetSlot(inventory[i]);
        }

        for (int i = 0; i < 9; i++)
        {
            hotbarPanel.GetComponent<InventorySlotUI>().SetSlot(inventory[i]);
        }
    }

    // Update is called once per frame
    void OnDestroy()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= Refresh;
    }
}
