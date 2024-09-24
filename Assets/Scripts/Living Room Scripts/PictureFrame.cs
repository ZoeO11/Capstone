using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFrame : MonoBehaviour
{
    public Sprite[] images;  // Array to store the individual images from the sprite sheet
    private int currentImageIndex;  // Keeps track of the current image index
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component

    private string saveKey = "PictureFrameImageIndex";  // Key for saving the current image index

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Load the saved image index, if exists; default to 0 (first image)
        currentImageIndex = PlayerPrefs.GetInt(saveKey, 0);

        // Set the current image based on the saved index
        spriteRenderer.sprite = images[currentImageIndex];
    }

    // Method to cycle through the images when the picture frame is clicked
    void OnMouseDown()
    {
        // Increment the image index and cycle back to 0 if at the last image
        currentImageIndex = (currentImageIndex + 1) % images.Length;

        // Update the sprite to the next image
        spriteRenderer.sprite = images[currentImageIndex];

        // Save the current image index so it persists
        PlayerPrefs.SetInt(saveKey, currentImageIndex);
        PlayerPrefs.Save();
    }

}
