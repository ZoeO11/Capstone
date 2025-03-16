using UnityEngine;


public class ItemClickHandler : MonoBehaviour
{
    public MoveableObject moveableObject; // Reference to the MoveableObject ScriptableObject
    public Inventory inventory; // Reference to the player's inventory
    public InventoryDisplay inventoryDisplay;

/*
    private void Start()
    {
        GameObject inventoryGameObject = GameObject.Find("InventoryManager"); // Find the inventory manager object
        if (inventoryGameObject != null)
        {
            inventoryDisplay = inventoryGameObject.GetComponent<InventoryDisplay>(); // Get InventoryDisplay component
            inventory = inventoryGameObject.GetComponent<Inventory>(); // Get Inventory component
        }
        else
        {
            Debug.LogError("InventoryManager not found in the scene!");
        }
    }
*/
    // You could also add a UI Button to this GameObject and add the OnClickListener to it
    /*private void Start()
    {
        // You can automatically register the OnClick event when the object is clicked
        Button button = GetComponent<Button>(); // Assuming the GameObject has a Button component
        if (button != null)
        {
            button.onClick.AddListener(AddItemToInventory); // Add listener for on-click
        }
    }
    */
    // This method will be called when the item is clicked
    public void OnMouseDown()
    {
        // Create a new ItemInstance (assuming you want to instantiate this in the scene)
        // GameObject itemInstance = new GameObject(moveableObject.objectName);
        // ItemInstance instanceScript = itemInstance.AddComponent<ItemInstance>();
        // instanceScript.objectData = moveableObject; // Set the MoveableObject reference

        // Try to add the item to the inventory
        //bool itemAdded = inventory.AddItem(instanceScript);


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
}