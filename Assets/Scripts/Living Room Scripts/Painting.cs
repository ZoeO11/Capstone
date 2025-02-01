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
    private ClickableItems painting;

    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Load the saved image index, if exists; default to 0 (first image)
        currentImageIndex = 0;

        // Set the current image based on the saved index
        Debug.Log($"currentImageIndex is {currentImageIndex}");
        spriteRenderer.sprite = images[currentImageIndex];
        painting = new ClickableItems("painting");
        painting.character_for_KC = "char1";

        painting.GetPrevValues();

    }

    // Method to cycle through the images when the picture frame is clicked
    void OnMouseDown()
    {
        Debug.Log("PAINTING CLICKED");

        painting.ChangeKnowledgeLevel(painting.character_for_KC);
        painting.UpdateVocabularyList();

        // Increment the image index and cycle back to 0 if at the last image
        currentImageIndex = (currentImageIndex + 1) % images.Length;

        // Update the sprite to the next image
        spriteRenderer.sprite = images[currentImageIndex];

        // Save the current image index so it persists
        PlayerPrefs.SetInt(saveKey, currentImageIndex);
        PlayerPrefs.Save();
    }

}