using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public Sprite[] images;  // Array to store the individual images from the sprite sheet
    private int currentImageIndex;  // Keeps track of the current image index
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    private PlayerData playerData;
    private GameItem painting;
    private string saveKey = "PaintingImageIndex";  // Key for saving the current image index

    void Start()
    {

        playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Load the saved image index, if exists; default to 0 (first image)
        currentImageIndex = PlayerPrefs.GetInt(saveKey, 0);

        // Set the current image based on the saved index
        Debug.Log($"currentImageIndex is {currentImageIndex}");
        spriteRenderer.sprite = images[currentImageIndex];


        // create instance of Object class here, and assign its name to Painting, etc.
        painting = new GameItem("painting");
        Debug.Log("Painting script started.");

        // check to see if painting already exists in the JSON vocab list.
        //   if it does, then assign its value to the painting object's knowledge level attribute
        if (playerData.vocabulary_dict.ContainsKey("painting"))
        {
            Debug.Log("'painting' already exists in vocab list!");
            painting.knowledgeLevel = playerData.vocabulary_dict["painting"];
        }
    }

    // Method to cycle through the images when the picture frame is clicked
    void OnMouseDown()
    {

        // THE ERROR OF NULL PAINTING OBJECT might be coming from the way you're
        // assigning the scripts to the gameobjects

        // increase the number of interactions to be +1
        // once it reaches a certain amount, prompt a test
        // if they pass, increase the knowledge level, etc.

        if (painting.interactionCount == 0)
        {
            Debug.Log("painting interaction = 0; updating to LEVEL_1");
            painting.SetKnowledgeLevel(KnowledgeLevel.LEVEL_1);
        }

        if (painting.interactionCount > 4)
        {
            // prompt knowledge assessment!
            // if pass, increase knowledge level

            // if not, set the interaction count to be minus 2 or smth
            // else:
            painting.SetKnowledgeLevel(KnowledgeLevel.LEVEL_2);
            Debug.Log("'painting' now has KL 2!");
        }
        else
        {
            // play the sound for painting eventually

            painting.IncreaseInteraction();
            Debug.Log($"'painting' count = {painting.interactionCount}");

        }


        // Increment the image index and cycle back to 0 if at the last image
        currentImageIndex = (currentImageIndex + 1) % images.Length;

        // Update the sprite to the next image
        spriteRenderer.sprite = images[currentImageIndex];

        // Save the current image index so it persists
        PlayerPrefs.SetInt(saveKey, currentImageIndex);
        PlayerPrefs.Save();
    }

    public void LeaveButton()
    {

        // Ensure playerData is not null
        if (playerData == null)
        {
            Debug.LogError("Player data is null! Cannot save knowledge level.");
            return; // Exit the method early
        }

        // Ensure painting is initialized
        if (painting == null)
        {
            Debug.LogError("Painting object is null! Cannot get knowledge level.");
            return; // Exit the method early
        }


        // update the knowledge to be that of the Object class instance for painting
        KnowledgeLevel knowledge_level = painting.GetKnowledgeLevel();
        Debug.Log($"Upon leaving, KL is {knowledge_level}");

        VocabularyEntry painting_vocab = new VocabularyEntry("painting", knowledge_level);
        // playerData.vocabulary_dict["painting"] = knowledge_level;
        playerData.vocabulary_list.Add(painting_vocab);


        //Debug.Log($"playerData.vocabulary is: {playerData.vocabulary_dict}");

        SaveSystem.SavePlayerData(playerData, GameManager.instance.GetCurrentGame());

        SceneManager.LoadScene("MainMenu");
    }

}
