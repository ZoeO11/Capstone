using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SaveData
{
    public string playerName;
    public string playerGender;
    public string nativeLanguage;
    public string targetLanguage;

    // Dictionary to store vocabulary, now storing the Object class instances
    public Dictionary<string, Object> vocabulary = new Dictionary<string, Object>();

    // Method to add or update a word in the vocabulary
    public void AddOrUpdateWord(string word)
    {
        if (vocabulary.ContainsKey(word))
        {
            // If the word exists, increment the interaction count
            vocabulary[word].interactionCount++;

            // Update the knowledge level based on interaction count
            vocabulary[word].UpdateKnowledgeLevel();
        }
        else
        {
            // If the word doesn't exist, create a new Object and set initial interaction count
            Object newObject = new Object(word, new Vector3());  // Assuming you need the Vector3 for position; if not, you can remove it
            newObject.interactionCount = 1;  // First interaction
            newObject.UpdateKnowledgeLevel();  // Set initial level to LEVEL_1
            vocabulary.Add(word, newObject);  // Add the new object to the dictionary
        }
    }

}