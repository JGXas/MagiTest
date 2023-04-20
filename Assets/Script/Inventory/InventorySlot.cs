using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventorySlot : MonoBehaviour
{
    [HideInInspector] public Item item;
    public Image icon;
    public TMP_Text amount;
    public Sprite iconTransparent;

    private InventoryManager inventoryManager;

    public void AddItem(Item newItem)
    {
        icon.overrideSprite = newItem.ItemImage;
        item = newItem;
    }

    public void RemoveItem()
    {
        icon.overrideSprite = null;
        item = null;
    }

    internal bool IsEmpty()
    {
        return item == null;
    }
}
