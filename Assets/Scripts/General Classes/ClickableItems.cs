using UnityEngine;

public class ClickableItems : GameItem
{
    public bool isClickable;
    public bool wordExistsInVocab;
    public int indexInVocab;
    private int interaction_count;
    private int wordExists;

    // Constructor
    public ClickableItems(string name) : base(name)
    {
        isClickable = true;
        objectName = name;
    }

    public int CheckIfWordExistsInVocab(PlayerData playerData)
    {
        for (int i = 0; i < playerData.vocabulary_list.Count; i++)
        {
            if (playerData.vocabulary_list[i].word == objectName)
            {
                return i; // Return the index of the word if found
            }
        }

        // If the word isn't found, return -1
        return -1;
    }
    public void GetPrevValues(PlayerData playerData)
    {
        wordExists = this.CheckIfWordExistsInVocab(playerData);

        if (wordExists != -1)
        {
            // wordExists is now the index of where the vocab word exists in the list

            // set the intermediate object's KL and IC to be that of the wordExists th entry of the list
            this.knowledgeLevel = playerData.vocabulary_list[wordExists].knowledgeLevel;
            this.interactionCount = playerData.vocabulary_list[wordExists].interactionCount;
            this.indexInVocab = wordExists;
            this.wordExistsInVocab = true;

        }
        else
        {
            this.wordExistsInVocab = false;
            this.indexInVocab = -1;
            wordExists = playerData.vocabulary_list.Count; // Index of most recently added word

        }
    }
    public void ChangeKnowledgeLevel()
    {
        this.IncreaseInteraction();
        interaction_count = this.GetInteractionCount();

        // set KL to level one the first time you click it
        if (interaction_count == 1)
        {
            this.SetKnowledgeLevel(KnowledgeLevel.LEVEL_1);
            Debug.Log("'plant' now has KL 1!");
        }

        if (this.interactionCount > 4 && this.interactionCount <= 13)
        {
            // prompt knowledge assessment!
            // if pass, increase knowledge level

            // if not, set the interaction count to be minus 2 or something
            this.SetKnowledgeLevel(KnowledgeLevel.LEVEL_2);
            Debug.Log("'plant' now has KL 2!");
        }

        if (interaction_count > 13)
        {
            this.SetKnowledgeLevel(KnowledgeLevel.LEVEL_3);
            Debug.Log("'plant' now has KL 3!");
        }

        // play the sound for painting eventually
        Debug.Log($"'plant' count = {this.interactionCount}");
    }
}


