using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public Animator myAnim;
    public bool InPopUp { get; set; }

    private bool buffer;

    public GameObject inventoryUI;

    public void PopUpItem(Item newItem)
    {
        StartCoroutine(Buffer());

        myAnim.SetBool("FadeIn", true);

        itemName.text = newItem.Name;
        itemDescription.text = newItem.Description;
        itemIcon.sprite = newItem.ItemImage;

        InventoryManager.instance.AddItem(newItem);
        InPopUp = true;
    }

    private void Update()
    {
        if (buffer == true) return;

        if (Input.GetButtonDown("Fire1"))
        {
            if (itemIcon.gameObject.activeSelf == true)
            {
                myAnim.SetBool("FadeIn", false);
                InPopUp = false;

                InventoryManager.instance.Update();
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (itemIcon.gameObject.activeSelf == true)
            {
                myAnim.SetBool("FadeIn", false);
                InPopUp = false;
            }
        }
    }

    private IEnumerator Buffer()
    {
        buffer = true;
        yield return new WaitForSeconds(0.1f);
        buffer = false;
    }
}
