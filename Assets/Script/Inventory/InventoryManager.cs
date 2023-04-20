using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory")]
    public static InventoryManager instance;
    public List<Item> inventory = new List<Item>();

    public delegate void OnItemAddCallBack(Item item);
    public OnItemAddCallBack onItemAddCallBack;

    public delegate void OnItemRemoveCallBack(Item item);
    public OnItemRemoveCallBack onItemRemoveCallBack;

    [SerializeField] private PlayerController playerController;
    private PauseManager pauseManager;

    //Referencias
    [Header("References")]
    public GameObject inventoryUI;
    public Button firstButton;
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public Image itemImage;
    public ItemPopUp itemPopUp;

    [HideInInspector] public bool inInventory;

    [SerializeField] private InventorySlot[] itemSlot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        itemSlot = GetComponentsInChildren<InventorySlot>();
    }

    public void AddItem(Item newItem)
    {
        inventory.Add(newItem);

        if (onItemAddCallBack != null) onItemAddCallBack.Invoke(newItem);
    }

    public void RemoveItem(Item newItem)
    {
        inventory.Remove(newItem);

        if (onItemRemoveCallBack != null) onItemRemoveCallBack.Invoke(newItem);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);

            OpenInventory();
        }
    }

    public void OpenInventory()
    {
        if (inventoryUI.activeSelf == true)
        {
            firstButton.Select();
            inInventory = true;
        }
        else
        {
            inInventory = false;
        }
    }
}
