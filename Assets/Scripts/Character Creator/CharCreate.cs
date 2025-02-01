using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles character creation, including styling and saving the data.
public class CharCreate : MonoBehaviour
{
    public List<CharElement> charElements = new List<CharElement>();
    public CharElement curEl;

    // Variables for all elements
    public Sprite[] currentSprites; // Sprite sheet elements
    public SpriteRenderer nextRender;
    public SpriteRenderer lastRender;
    public SpriteRenderer pRender;

    // Variables to track shape
    public int nextShapeTrack = 0;
    public int lastShapeTrack = 0;
    public int pShapeTrack = 0;

    // Variables to track index
    public int lastIndex = 0;
    public int pIndex = 0;
    public int nextIndex = 1;

    // Hair-specific variables
    public Sprite[] bangStyles;
    public SpriteRenderer bangRenderer;
    public int lastHairColor = 0;
    public int pHairColor = 0;

    private PlayerData playerData;

    void Start()
    {
        // Attempt to load player data
        playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());

        if (playerData != null)
        {
            // Apply the saved hair style and color
            pIndex = playerData.hairStyleIndex;
            pHairColor = playerData.hairColorIndex;

            // Load hair customization
            ChangeHairColor();
            SetStyle(); // Render the saved hair style
        }
        else
        {
            // Default behavior if no data exists
            Debug.Log("No existing player data found. Starting with default settings.");
            curEl = charElements[0];
            ElementSelect();
        }
    }

    public void ElementSelect() // Called when selecting an element (e.g., hair, outfit)
    {
        currentSprites = Resources.LoadAll<Sprite>(curEl.PNG);
        ReRender();

        lastIndex = curEl.numShapes - 1;
        pIndex = 0;
        nextIndex = 1;
        nextShapeTrack = 1;
        lastShapeTrack = curEl.numShapes - 1;
    }

    public void ReRender() // Updates previews for shape/style
    {
        nextRender.sprite = currentSprites[nextIndex];
        lastRender.sprite = currentSprites[lastIndex];
        pRender.sprite = currentSprites[pIndex];
    }

    public void ElementMinus() // Called when right arrow is pressed
    {
        lastIndex = pIndex;
        lastShapeTrack = pShapeTrack;
        pIndex = nextIndex;
        pShapeTrack = nextShapeTrack;
        nextShapeTrack++;

        if (nextShapeTrack == curEl.numShapes)
        {
            nextShapeTrack = 0;
            nextIndex -= curEl.numShapes - 1;
        }
        else
        {
            nextIndex++;
        }
        ReRender();
    }

    public void ElementPlus() // Called when left arrow is pressed
    {
        nextIndex = pIndex;
        nextShapeTrack = pShapeTrack;
        pIndex = lastIndex;
        pShapeTrack = lastShapeTrack;

        if (lastShapeTrack == 0)
        {
            lastShapeTrack = curEl.numShapes - 1;
            lastIndex += curEl.numShapes - 1;
        }
        else
        {
            lastIndex--;
            lastShapeTrack--;
        }
        ReRender();
    }

    public void SetStyle() // Called when selecting a specific style
    {
        curEl.render.sprite = currentSprites[pIndex];

        if (curEl.element == "Hair") // Render bangs based on hair
        {
            bangStyles = Resources.LoadAll<Sprite>("CharacterCreator/BangV2");
            bangRenderer.sprite = bangStyles[pIndex];
        }
    }

    public void ChangeHairColor() // Handles hair color changes
    {
        lastIndex = pHairColor * curEl.numShapes + lastShapeTrack;
        nextIndex = pHairColor * curEl.numShapes + nextShapeTrack;
        pIndex = pHairColor * curEl.numShapes + pShapeTrack;
        ReRender();
    }

    public void ContinueButton() // Called when continuing to the next scene
    {
        if (playerData == null)
        {
            playerData = new PlayerData(); // Initialize if null
        }

        // Update hair style and color
        playerData.hairStyleIndex = pIndex;
        playerData.hairColorIndex = pHairColor;

        // Save player data
        SaveSystem.SavePlayerData(playerData, GameManager.instance.GetCurrentGame());
        Debug.Log($"Game {GameManager.instance.GetCurrentGame()} saved successfully.");

        // Load the next scene
        SceneManager.LoadScene("Home");
    }
}
