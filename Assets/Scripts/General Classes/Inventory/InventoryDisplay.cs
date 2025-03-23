using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public ItemDisplay[] slots;
    public int i = 0;
    public Vector3 dropBasePosition = new Vector3(0.5f, 0.5f, -1);
    public Vector3 dropPositionRange = new Vector3(1f, 1f, 0f);
    public Collider2D newCollider;

    private void Start()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        Debug.Log("update inventory");
        for (int i = 0; i < inventory.maxItems; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].gameObject.SetActive(true);
                slots[i].UpdateItemDisplay(inventory.items[i].icon, i);
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
        if (index >= 0 && index < inventory.items.Count)
        {
            // spawning the item in the game world here
            MoveableObject itemToDrop = inventory.items[index];

            // If you want to spawn the item in the game world
            if (itemToDrop != null)
            {

                Vector3 randomOffset = new Vector3(
                    Random.Range(-dropPositionRange.x, dropPositionRange.x),
                    Random.Range(-dropPositionRange.y, dropPositionRange.y),
                    Random.Range(-dropPositionRange.z, dropPositionRange.z)
                );

                // Calculate the final drop position.
                Vector3 dropPosition = dropBasePosition + randomOffset;

                // Example: Instantiate the dropped item in the game world at some position
                GameObject droppedItem = Instantiate(itemToDrop.prefab, dropPosition, Quaternion.identity); // Change the position as needed
                ItemClickHandler clickHandler = droppedItem.GetComponent<ItemClickHandler>();
                //InventoryDisplay inventoryDisplay = ItemClickHandler.inventoryDisplay;
                //itemToDrop.gameObject.SetActive(true);
                if (clickHandler != null)
                {
                    clickHandler.inventoryDisplay = this;
                    clickHandler.myCollider = newCollider;
                }
            }

            // Remove the item from the inventory
            inventory.items.RemoveAt(index);


            // Update the UI
            UpdateInventory();
        }
    }

}