using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemDisplay : MonoBehaviour
{
    public InventoryDisplay inventoryDisplay;
    public int itemIndex;
    public Image image;

    public void UpdateItemDisplay(Sprite newSprite, int newItemIndex)
    {
        Debug.Log(newSprite);
        image.sprite = newSprite;
        itemIndex = newItemIndex;
    }

    public void DropFromInventory()
    {
        inventoryDisplay.DropItem(itemIndex);
    }

}
