using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;

    private bool menuActivated;

    public ItemSlot[] itemSlot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        if (itemSlot == null || itemSlot.Length == 0)
        {
            Debug.LogError("ItemSlot is empty");
            return;

        }

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i] == null)
            {
                Debug.LogError($"itemSlot{i} is null");
                continue;
            }

            if (!itemSlot[i].isFull)
            {
                Debug.Log($"Adding item to slot {i}: {itemName} (x{quantity})");
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }

            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
    }
}