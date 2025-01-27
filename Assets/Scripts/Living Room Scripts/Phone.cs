using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private PlayerData playerData;
    private ClickableItems phone;
    public GameObject phoneAnimation;
    public GameObject phoneBack;
     bool isPhoneActivated = false;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());
        phone = new ClickableItems("phone");
        phone.GetPrevValues(playerData);
        SaveSystem.clickableObjectsList.Add(phone);
        if (phoneAnimation != null)
        {
            phoneAnimation.SetActive(false);
            phoneBack.SetActive(false);
        }
    }
    void OnMouseDown()
    {
        ActivatePhone();
        Debug.Log("PHONE CLICKED");
        phone.ChangeKnowledgeLevel(playerData, "test");
    }
    void ActivatePhone()
    {
        if (phoneAnimation != null)
        {
            phoneAnimation.SetActive(true); // Make the phone animation appear
            phoneBack.SetActive(true);
    
        }
    }
}
