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
        if (index >= 0 && index < inventory.items.Count)
        {
            MoveableObject itemToDrop = inventory.items[index];

            if (itemToDrop != null)
            {
                // Drop the item in front of the camera instead of random offset
                Vector3 dropPosition = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
                dropPosition.z = -3f;

                GameObject droppedItem = Instantiate(itemToDrop.prefab, dropPosition, Quaternion.identity);

                ItemClickHandler clickHandler = droppedItem.GetComponent<ItemClickHandler>();
                if (clickHandler != null)
                {
                    clickHandler.inventoryDisplay = this;
                    clickHandler.myCollider = newCollider;
                }
            }

            inventory.items.RemoveAt(index);
            UpdateInventory();
        }
    }


}