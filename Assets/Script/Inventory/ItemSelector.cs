using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSelector : MonoBehaviour, ISelectHandler
{
    private InventorySlot inventorySlot;

    private void Awake()
    {
        inventorySlot = GetComponent<InventorySlot>();
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (inventorySlot.item != null)
        {
            InventoryManager.instance.itemName.text = inventorySlot.item.Name;
            InventoryManager.instance.itemDescription.text = inventorySlot.item.Description;
            InventoryManager.instance.itemImage.sprite = inventorySlot.item.ItemImage;
        }
        else
        {
            InventoryManager.instance.itemName.text = "";
            InventoryManager.instance.itemDescription.text = "";
            InventoryManager.instance.itemImage.sprite = inventorySlot.iconTransparent;
        }
    }
}
