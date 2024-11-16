using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Couch : MonoBehaviour
{
    private PlayerData playerData;
    private ClickableItems couch;
    private int wordExists;
    private int interaction_count;

    void Start()
    {

        playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());
        couch = new ClickableItems("couch");
        wordExists = couch.CheckIfWordExistsInVocab(playerData);

        if (wordExists != -1)
        {
            // wordExists is now the index of where the vocab word exists in the list

            // set the intermediate object's KL and IC to be that of the wordExists th entry of the list
            couch.knowledgeLevel = playerData.vocabulary_list[wordExists].knowledgeLevel;
            couch.interactionCount = playerData.vocabulary_list[wordExists].interactionCount;
            couch.indexInVocab = wordExists;
            couch.wordExistsInVocab = true;

        }
        else
        {
            couch.wordExistsInVocab = false;
            couch.indexInVocab = -1;
            wordExists = playerData.vocabulary_list.Count; // Index of most recently added word

        }

        SaveSystem.clickableObjectsList.Add(couch);

    }

    // Method to cycle through the images when the picture frame is clicked
    void OnMouseDown()
    {
        Debug.Log("COUCH CLICKED");

        couch.IncreaseInteraction();
        interaction_count = couch.GetInteractionCount();

        // set KL to level one the first time you click it
        if (interaction_count == 1)
        {
            couch.SetKnowledgeLevel(KnowledgeLevel.LEVEL_1);
            Debug.Log("'couch' now has KL 1!");
        }

        if (couch.interactionCount > 4 && couch.interactionCount <= 13)
        {
            // prompt knowledge assessment!
            // if pass, increase knowledge level

            // if not, set the interaction count to be minus 2 or something
            couch.SetKnowledgeLevel(KnowledgeLevel.LEVEL_2);
            Debug.Log("'couch' now has KL 2!");
        }

        if (interaction_count > 13)
        {
            couch.SetKnowledgeLevel(KnowledgeLevel.LEVEL_3);
            Debug.Log("'couch' now has KL 3!");
        }

            // play the sound for painting eventually
        Debug.Log($"'couch' count = {couch.interactionCount}");


    }

    // script to attach to other Go Back button
    public void BackButton()
    {

        // call function that iterates over interacted objects, and saves them out to JSON
        SaveSystem.SaveClickedObjects(playerData);
        SaveSystem.SavePlayerData(playerData, GameManager.instance.GetCurrentGame());
        SceneManager.LoadScene("MainMenu");

    }
}
