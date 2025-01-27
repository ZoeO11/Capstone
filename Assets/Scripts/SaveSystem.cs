using System.IO;
using UnityEngine;
using System.Collections.Generic;

// The Save class will handle saving and loading playerData to and from files.
// This ensures data persistence between sessions.


public class SaveSystem
{
    public static List<ClickableItems> clickableObjectsList = new List<ClickableItems>();
    public static List<List<string>> characterLists = new List<List<string>>();


    public static void SavePlayerData(PlayerData playerData, string gameName)
    {
        string path = Application.persistentDataPath + "/" + gameName + ".save";
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, json);
    }

    public static PlayerData LoadPlayerData(string gameName)
    {
        string path = Application.persistentDataPath + "/" + gameName + ".save";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        return null;
    }

    public static void SaveClickedObjects(PlayerData playerData)
    {
        // Iterate through all clickable items
        foreach (ClickableItems clickableItem in clickableObjectsList)
        {
            KnowledgeLevel knowledge_level = clickableItem.GetKnowledgeLevel();
            int final_interaction_count = clickableItem.GetInteractionCount();

            // If the word doesn't exist in the vocabulary, add it
            if (!clickableItem.wordExistsInVocab)
            {
                // Check if the word already exists in the vocabulary list
                int vocabIndex = clickableItem.CheckIfWordExistsInVocab(playerData);

                if (vocabIndex == -1)
                {
                    // The word doesn't exist, so add a new entry
                    VocabularyEntry vocab = new VocabularyEntry(clickableItem.objectName, knowledge_level);
                    vocab.interactionCount = final_interaction_count;
                    playerData.vocabulary_list.Add(vocab);

                    // Mark the word as added to vocab
                    clickableItem.wordExistsInVocab = true;
                    clickableItem.indexInVocab = playerData.vocabulary_list.Count - 1;
                }
                else
                {
                    // The word already exists, update its information
                    playerData.vocabulary_list[vocabIndex].knowledgeLevel = knowledge_level;
                    playerData.vocabulary_list[vocabIndex].interactionCount = final_interaction_count;
                }
            }
            else
            {
                // If the word already exists, just update it
                playerData.vocabulary_list[clickableItem.indexInVocab].knowledgeLevel = knowledge_level;
                playerData.vocabulary_list[clickableItem.indexInVocab].interactionCount = final_interaction_count;
            }
        }
    }
    public static void SaveCharLists(PlayerData playerData)
    {
        foreach (List<string> char_list in characterLists)
        {
            
            playerData.char_list = 
        }
    }



}
