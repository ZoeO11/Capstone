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
        phone = new ClickableItems("phone");
        phone.character_for_KC = "char1";
        phone.GetPrevValues();  // Get previous values (knowledge level, interaction count)

        if (phoneAnimation != null)
        {
            phoneAnimation.SetActive(false);  // Ensure phone animation is initially hidden
            phoneBack.SetActive(false);  // Hide phone back initially
        }
    }

    void OnMouseDown()
    {
        ActivatePhone();
        Debug.Log("PHONE CLICKED");
        phone.ChangeKnowledgeLevel(phone.character_for_KC);  // Increase interaction count
        phone.UpdateVocabularyList();
    }

    void ActivatePhone()
    {
        if (phoneAnimation != null)
        {
            phoneAnimation.SetActive(true);  // Show phone animation
            phoneBack.SetActive(true);  // Show phone back
        }
    }
}
