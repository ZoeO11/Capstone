using UnityEngine;
using System.Collections.Generic;

public class ClickableItems : GameItem
{
    public bool isClickable;
    public bool wordExistsInVocab;
    public int indexInVocab;
    private int interaction_count;
    public string character_for_KC;
    private PlayerData playerData;  // Add a reference to playerData

    // Constructor
    public ClickableItems(string name) : base(name)
    {
        isClickable = true;
        objectName = name;
        wordExistsInVocab = false;
        indexInVocab = -1;

        // Initialize playerData from GameManager
        playerData = GameManager.playerData;  // Use the static playerData from GameManager
    }

    // Check if the word exists in the player's vocabulary list
    public int CheckIfWordExistsInVocab()
    {
        if (playerData == null)
        {
            Debug.LogError("Player data is not initialized.");
            return -1;  // Return -1 if playerData is not set
        }

        for (int i = 0; i < playerData.vocabulary_list.Count; i++)
        {
            if (playerData.vocabulary_list[i].word == objectName)
            {
                return i; // Return the index of the word if found
            }
        }
        return -1; // Return -1 if the word isn't found
    }

    // Set up previous values for knowledge level and interaction count based on vocab
    public void GetPrevValues()
    {
        int wordExists = CheckIfWordExistsInVocab();

        if (wordExists != -1)
        {
            this.knowledgeLevel = playerData.vocabulary_list[wordExists].knowledgeLevel;
            this.interactionCount = playerData.vocabulary_list[wordExists].interactionCount;
            this.indexInVocab = wordExists;
            this.wordExistsInVocab = true;
        }
        else
        {
            this.wordExistsInVocab = false;
            this.indexInVocab = -1;
        }
    }

    // Update knowledge level and handle special tasks when a certain interaction count is reached
    public void ChangeKnowledgeLevel(string character)
    {
        this.IncreaseInteraction();
        interaction_count = this.GetInteractionCount();
        Debug.Log($"{this.objectName} int count: {interaction_count}");
        Debug.Log($"{this.objectName} KL: {this.GetKnowledgeLevel()}");

        if (interaction_count == 1)
        {
            this.SetKnowledgeLevel(KnowledgeLevel.LEVEL_1);
        }

        if (interaction_count == 5)
        {
            string task = $"Find the {objectName}.";

            // adding to general 'task' list for now
            if (this.character_for_KC == "char1")
            {
                playerData.char1_list.Add(task);
            }
            
           
        }

        if (interaction_count == 13)
        {
            this.SetKnowledgeLevel(KnowledgeLevel.LEVEL_2);
        }

        if (interaction_count > 20)
        {
            this.SetKnowledgeLevel(KnowledgeLevel.LEVEL_3);
        }
    }

    public void UpdateVocabularyList()
    {
        if (playerData == null)
        {
            Debug.LogError("Player data is not initialized.");
            return;  // Prevent the method from running if playerData is not set
        }

        // Look for the word in the player's vocabulary list
        VocabularyEntry entry = playerData.vocabulary_list.Find(v => v.word == this.objectName);

        if (entry == null)
        {
            // If not found, add a new entry
            VocabularyEntry newEntry = new VocabularyEntry(this.objectName, this.GetInteractionCount(), this.GetKnowledgeLevel());
            playerData.vocabulary_list.Add(newEntry);
            entry = newEntry;
        }
        else
        {
            entry.interactionCount = this.GetInteractionCount();
            entry.knowledgeLevel = this.GetKnowledgeLevel();
        }

    }

        
}
