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
    bool wordExists = false;

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


        // ACCESS THE PLAYER'S VOCAB DICTIONARY; IF THE VOCAB LIST DOESN'T CONTAIN 'PAINTING', THEN ADD IT AS LEVEL1
        for (int i = 0; i < playerData.vocabulary_list.Count; i++)
        {
            if (playerData.vocabulary_list[i].word == "painting")
            {
                Debug.Log("'painting' already exists in the vocabulary list!");
                painting.knowledgeLevel = playerData.vocabulary_list[i].knowledgeLevel;
                painting.interactionCount = playerData.vocabulary_list[i].interactionCount;
                wordExists = true;
                break;
            }
        }

    }

    // Method to cycle through the images when the picture frame is clicked
    void OnMouseDown()
    {
        // increase the number of interactions to be +1
        // once it reaches a certain amount, prompt a test
        // if they pass, increase the knowledge level, etc.



        // CHECK IF IS CLICKABLE, THEN


        painting.IncreaseInteraction();

        // set KL to level one the first time you click it
        if (painting.interactionCount == 1)
        {
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

        // update the knowledge to be that of the Object class instance for painting
        KnowledgeLevel knowledge_level = painting.GetKnowledgeLevel();
        int final_interaction_count = painting.GetInteractionCount();
        Debug.Log($"Upon leaving, KL is {knowledge_level}");


        // if wordExists is false, then do this:
        if (!wordExists)
        {
            VocabularyEntry painting_vocab = new VocabularyEntry("painting", knowledge_level);
            painting_vocab.interactionCount = final_interaction_count;
            playerData.vocabulary_list.Add(painting_vocab);
            Debug.Log($"playerData vocab list is now: {playerData.vocabulary_list}");
        }
        // word already exists in vocab list; just update to newest KL
        else
        {
            for (int j = 0; j < playerData.vocabulary_list.Count; j++)
            {
                if (playerData.vocabulary_list[j].word == "painting")
                {
                    // Word found, update its knowledge level
                    playerData.vocabulary_list[j].knowledgeLevel = knowledge_level;
                    playerData.vocabulary_list[j].interactionCount = final_interaction_count;
                    Debug.Log($"Updated 'painting' knowledge level to {knowledge_level}");
                    Debug.Log($"Updated 'painting' interaction count to {final_interaction_count}");
                    break;
                }
            }

        }

        SaveSystem.SavePlayerData(playerData, GameManager.instance.GetCurrentGame());

        SceneManager.LoadScene("MainMenu");
    }

}
