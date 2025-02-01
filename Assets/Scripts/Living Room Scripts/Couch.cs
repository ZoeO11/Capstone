using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : MonoBehaviour
{
    private ClickableItems couch;

    void Start()
    {
        // Initialize couch as a clickable item
        couch = new ClickableItems("couch");
        couch.character_for_KC = "char1"; // Assuming this is the character you're tracking

        // Retrieve previous data for the couch
        couch.GetPrevValues();
    }

    // Method to cycle through the images when the picture frame is clicked
    void OnMouseDown()
    {
        Debug.Log("COUCH CLICKED");

        // Update the interaction count and knowledge level
        couch.ChangeKnowledgeLevel(couch.character_for_KC);

        // Update vocabulary list after interaction
        couch.UpdateVocabularyList();
    }
}
