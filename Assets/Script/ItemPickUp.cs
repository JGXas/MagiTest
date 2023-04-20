using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private Item item;

    public void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (Input.GetButton("Fire1"))
        {
            InventoryManager.instance.itemPopUp.PopUpItem(item);
            Destroy(gameObject);
        }

    }

    public void Interact()
    {
        //InventoryManager.instance.AddItem(item);
        //InventoryManager.instance.itemPopUp.PopUpItem(item);
        //Destroy(itemColectable);
    }
}
