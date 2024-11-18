using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public Sprite[] images;  // Array to store the individual images from the sprite sheet
    private int currentImageIndex;  // Keeps track of the current image index
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    private string saveKey = "PaintingImageIndex";  // Key for saving the current image index
    private PlayerData playerData;
    private ClickableItems painting;
    private int wordExists;
    private int interaction_count;
    FindGameItem first_kc;
    int result;

    void Start()
    {

        playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Load the saved image index, if exists; default to 0 (first image)
        currentImageIndex = 0;

        // Set the current image based on the saved index
        Debug.Log($"currentImageIndex is {currentImageIndex}");
        spriteRenderer.sprite = images[currentImageIndex];
        painting = new ClickableItems("painting");
        wordExists = painting.CheckIfWordExistsInVocab(playerData);

        if (wordExists != -1)
        {
            // wordExists is now the index of where the vocab word exists in the list

            // set the intermediate object's KL and IC to be that of the wordExists th entry of the list
            painting.knowledgeLevel = playerData.vocabulary_list[wordExists].knowledgeLevel;
            painting.interactionCount = playerData.vocabulary_list[wordExists].interactionCount;
            painting.indexInVocab = wordExists;
            painting.wordExistsInVocab = true;

        }
        else
        {
            painting.wordExistsInVocab = false;
            painting.indexInVocab = -1;
            wordExists = playerData.vocabulary_list.Count; // Index of most recently added word

        }

        SaveSystem.clickableObjectsList.Add(painting);

    }

    // Method to cycle through the images when the picture frame is clicked
    void OnMouseDown()
    {
        Debug.Log("PAINTING CLICKED");

        painting.IncreaseInteraction();
        interaction_count = painting.GetInteractionCount();

        // set KL to level one the first time you click it
        if (interaction_count == 1)
        {
            painting.SetKnowledgeLevel(KnowledgeLevel.LEVEL_1);
            Debug.Log("'painting' now has KL 1!");
        }

        if (painting.interactionCount == 5)
        {
            // prompt knowledge assessment!

            /*first_kc = new FindGameItem();

            result = first_kc.LoadFindItemKC(painting, playerData);

            if (result == 0)
            {
                Debug.Log("You passed! 'painting' now has KL 2");
                painting.SetKnowledgeLevel(KnowledgeLevel.LEVEL_2);
            }

            else
            {
                painting.interactionCount = 0;
            } */


        }

        if (interaction_count > 13)
        {
            painting.SetKnowledgeLevel(KnowledgeLevel.LEVEL_3);
            Debug.Log("'painting' now has KL 3!");
        }

        // play the sound for painting eventually
        Debug.Log($"'painting' count = {painting.interactionCount}");

        // Increment the image index and cycle back to 0 if at the last image
        currentImageIndex = (currentImageIndex + 1) % images.Length;

        // Update the sprite to the next image
        spriteRenderer.sprite = images[currentImageIndex];

        // Save the current image index so it persists
        PlayerPrefs.SetInt(saveKey, currentImageIndex);
        PlayerPrefs.Save();
    }

}
