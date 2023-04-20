using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryUI : MonoBehaviour
{
    [HideInInspector] public InventorySlot[] slots;

    private void Start()
    {
        slots = GetComponentsInChildren<InventorySlot>();

        InventoryManager.instance.onItemAddCallBack += UpdateInventoyAdd;
        InventoryManager.instance.onItemRemoveCallBack += UpdateInventoryRemove;
    }

    private int? GetNextEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i].item == null) return i;
        }

        return null;
    }

    private int? GetSameSlot(Item newItem)
    {
        for (int i = slots.Length - 1; i >= 0 ; i--)
        {
            if (slots[i].item != null)
            {
                if (slots[i].item == newItem) return i;
            }
        }

        return null;
    }

    public void UpdateInventoyAdd(Item newItem)
    {
        var remainder = GetRemainder(newItem);

        if (remainder == 0)
        {
            remainder = newItem.MaxStackSize;
        }
        
        if (remainder == 1)
        {
            Debug.Log("Item Adicionado");
            slots[(int)GetNextEmptySlot()].AddItem(newItem);
        }
        else
        {
            slots[(int)GetSameSlot(newItem)].amount.text = remainder.ToString();
        }
        
    }

    public void UpdateInventoryRemove(Item newItem)
    {
        var remainder = GetRemainder(newItem);

        if (remainder == 0)
        {
            remainder = newItem.MaxStackSize;
        }
        
        if (remainder == newItem.MaxStackSize)
        {
            slots[(int)GetSameSlot(newItem)].amount.text = "";
            slots[(int)GetSameSlot(newItem)].RemoveItem();
        }
        else
        {
            slots[(int)GetSameSlot(newItem)].amount.text = remainder.ToString();
        }
    }

    private int GetRemainder(Item newItem)
    {
        var itemCount = InventoryManager.instance.inventory.Count(x => x == newItem);
        return itemCount % newItem.MaxStackSize;
    }
}
