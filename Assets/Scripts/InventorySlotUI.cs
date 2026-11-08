using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
  [SerializeField] private Image icon;
  [SerializeField] private TextMeshProUGUI amountText;

  public void SetSlot(InventorySlot slot)
  {
    if (slot.IsEmpty)
    {
      icon.enabled = false;
      amountText.text = "";
      return;
    }

    icon.enabled = true;
    icon.sprite = slot.item.icon;

    amountText.text = slot.amount > 1 ? slot.amount.ToString() : "";
  }
}