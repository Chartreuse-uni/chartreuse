
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //Item Data
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;

    //Item Slot
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;


public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;


        //Debugging
        Debug.Log($"Adding item: {itemName}, Quantity: {quantity}");

        if (quantityText == null)
        {
            Debug.LogError("quantityText is not assigned");
            return;
        }
        if (itemImage == null)
        {
            Debug.LogError("itemImage is not assigned");
            return;
        }
        if(itemSprite == null)
        {
            Debug.LogError("itemSprite is null");
            return;
        }

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;

        itemImage.sprite = itemSprite;
        itemImage.enabled = true;

        Debug.Log("Item added to slot");
    }


}
