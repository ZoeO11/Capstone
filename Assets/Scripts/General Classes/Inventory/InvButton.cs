using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvButton : MonoBehaviour
{
    public GameObject inventoryUI;

    private void Start()
    {
        inventoryUI.SetActive(false);
    }

    public void InventoryButton()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    public void InventoryCloseButton()
    {
        inventoryUI.SetActive(false);
    }
}
