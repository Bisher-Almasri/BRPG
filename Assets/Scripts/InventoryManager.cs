using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] private int inventorySize = 36;

    public InventorySlot[] Slots { get; private set; }

    public event System.Action OnInventoryChanged;

    void Awake()
    {
        Instance = this;

        Slots = new InventorySlot[inventorySize];

        for (int i = 0; i < inventorySize; i++)
        {
            Slots[i] = new InventorySlot();
        }
    }

    public int AddItem(Item item, int amount = 1)
    {
        if (item == null || amount <= 0)
            return amount;

        int remaining = amount;
        int maxStack = item.isStackable ? Mathf.Max(1, item.maxStack) : 1;

        for (int i = 0; i < Slots.Length; i++)
        {
            InventorySlot slot = Slots[i];

            if (slot.IsEmpty || slot.item != item)
              continue;
            
            int space = maxStack - slot.amount;
            int toAdd = Mathf.Min(space, remaining);

            slot.amount += toAdd;
            remaining -= toAdd;

            if (remaining == 0)
                break;
        }

        for (int i = 0; i < Slots.Length; i++)
        {
            InventorySlot slot = Slots[i];

            if (!slot.IsEmpty)
                continue;
            
            int toAdd = Mathf.Min(maxStack, remaining);
            
            slot.item = item;
            slot.amount = toAdd;
            remaining -= toAdd;
        }

        if (remaining != amount)
            OnInventoryChanged.Invoke();
        
        return remaining;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
