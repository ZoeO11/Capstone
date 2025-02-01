using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private ClickableItems plant;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

         // Initialize plant as a clickable item with the loaded player data
         plant = new ClickableItems("plant");
         plant.character_for_KC = "char1"; // Assuming this is the character you're tracking

         // Retrieve previous data for the plant
         plant.GetPrevValues();
        
    }

    void OnMouseDown()
    {
        anim.SetTrigger("onclickanimate");
        Debug.Log("PLANT CLICKED");

        // Update the knowledge level and handle the plant's task logic
        plant.ChangeKnowledgeLevel(plant.character_for_KC);

        // Make sure to update the vocabulary list after interaction
        plant.UpdateVocabularyList();
    }
}
