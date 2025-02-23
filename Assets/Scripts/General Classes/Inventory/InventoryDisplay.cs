using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public ItemDisplay[] slots;
    public int i = 0;

    private void Start()
    {
        //UpdateInventory();
    }

    public void UpdateInventory()
    {
        Debug.Log("update inventory");
        for (int i = 0; i < inventory.maxItems; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].UpdateItemDisplay(inventory.items[i].objectData.icon, i);
            }
            else
            {
                slots[i].gameObject.SetActive(false);
                slots[i].UpdateItemDisplay(null, i);
            }
        }
    }
    /*   
     {
       Debug.Log($"{inventory.items} slay");
       slots[i].gameObject.SetActive(true);
       //Debug.Log(inventory.items[i]); -- this is the issue
       Debug.Log($"{i} LOL");

       i++;

     }
   else
     {

     }

} */

    public void DropItem(int index)
    {
        // Check if the index is valid
        Debug.Log("called DropItem");
        if (index >= 0 && index < inventory.items.Count)
        {
            // spawning the item in the game world here
            ItemInstance itemToDrop = inventory.items[index];

            Debug.Log($"{itemToDrop} please");

            // If you want to spawn the item in the game world
            if (itemToDrop != null && itemToDrop.objectData != null)
            {
                Debug.Log("trying to instantiate");
                // Example: Instantiate the dropped item in the game world at some position
                Instantiate(itemToDrop.objectData.prefab, new Vector3(0.5f, 0.5f, -1), Quaternion.identity); // Change the position as needed
                //InventoryDisplay inventoryDisplay = ItemClickHandler.inventoryDisplay;
                //itemToDrop.gameObject.SetActive(true);
            }

            // Remove the item from the inventory
            inventory.items.RemoveAt(index);


            // Update the UI
            UpdateInventory();
        }
    }

}