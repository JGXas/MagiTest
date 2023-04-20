using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Test : MonoBehaviour
{
    public Item item1;
    public Item item2;
    public Item item3;
    public Item item4;
    public Item item5;

    public void Update()
    {
        //Adicionar
        if (Input.GetKeyDown(KeyCode.Z))
        {
            InventoryManager.instance.AddItem(item1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            InventoryManager.instance.AddItem(item2);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            InventoryManager.instance.AddItem(item3);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            InventoryManager.instance.AddItem(item4);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            InventoryManager.instance.AddItem(item5);
        }

        //Remover
        if (Input.GetKeyDown(KeyCode.F))
        {
            InventoryManager.instance.RemoveItem(item1);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            InventoryManager.instance.RemoveItem(item2);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            InventoryManager.instance.RemoveItem(item3);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            InventoryManager.instance.RemoveItem(item4);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            InventoryManager.instance.RemoveItem(item5);
        }
    }
}
