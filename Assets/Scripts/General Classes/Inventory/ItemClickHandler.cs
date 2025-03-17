using UnityEngine;


public class ItemClickHandler : MonoBehaviour
{
    public MoveableObject moveableObject; // Reference to the MoveableObject ScriptableObject
    public Inventory inventory; // Reference to the player's inventory
    public InventoryDisplay inventoryDisplay;
    public Collider2D myCollider;
    public bool isBeingDragged = false;

    public void OnMouseDown()
    {
        isBeingDragged = true;
        
    }

    public void OnMouseDrag()
    {
        if (isBeingDragged)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, mousePosition.y); // Move item to follow mouse
        }
    }
    public void OnMouseUp()
    {
        isBeingDragged = false;
        CheckIfDroppedOnInventory();
    }
    public void CheckIfDroppedOnInventory()
    {
        Debug.Log("checking");

        // Assuming the Inventory button has a BoxCollider2D or similar attached
        //Collider2D inventoryButtonCollider = GameObject.FindWithTag("InventoryButton").GetComponent<Collider2D>();
        if (myCollider.OverlapPoint(transform.position))
        {
            Debug.Log("overlap");
            // If dropped on the inventory button, try to add to the inventory
            bool itemAdded = inventory.AddItem(moveableObject);

            if (itemAdded)
            {
                Destroy(gameObject);
                inventoryDisplay.UpdateInventory(); // Update UI after adding item
            }
            else
            {
                Debug.Log("Inventory full, cannot add item.");
            }
        }
        // If not dropped on inventory button, no need to reset the position; just leave it where it is
    }
}