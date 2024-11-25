using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }

// Ensure that the collider attached to this object has "Is Trigger" enabled.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Collision detected with: {other.gameObject.name}");
        if (other.gameObject.tag == "Player") // Check if the object that entered the trigger is the player
        {
            inventoryManager.AddItem(itemName, quantity, sprite);
            
            Destroy(gameObject); // Destroy the object after it has been picked up
            Debug.Log("Item added to inventory. Destroying item object."); 
        }
    }

}
