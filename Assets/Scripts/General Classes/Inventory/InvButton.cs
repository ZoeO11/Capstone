using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvButton : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject screenBlock;

    private void Start()
    {
        inventoryUI.SetActive(false);
        screenBlock.SetActive(false);
    }

    public void InventoryButton()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        screenBlock.SetActive(true);
    }

    public void InventoryCloseButton()
    {
        inventoryUI.SetActive(false);
        screenBlock.SetActive(false);
    }
}
