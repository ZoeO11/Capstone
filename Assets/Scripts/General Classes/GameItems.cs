using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum KnowledgeLevel
{
    HAS_NOT_SEEN,
    LEVEL_1,
    LEVEL_2,
    LEVEL_3
}

[System.Serializable]
public class GameItem
{
    public string objectName;   // Name of the object
    public KnowledgeLevel knowledgeLevel;   // User's knowledge level of the object 
    public int interactionCount;  // Track how many times the object has been interacted with
    public Sprite itemSprite;   // Visual representation of the object

    // Constructor to initialize an object
    public GameItem(string name)
    {
        objectName = name;
        knowledgeLevel = KnowledgeLevel.HAS_NOT_SEEN;  // Initially set to HAS_NOT_SEEN
        interactionCount = 0;  // Initially set interaction count to 0
        itemSprite = null;  // Set sprite to null by default
    }

    // Method to increase interaction count and update knowledge level accordingly
    public void IncreaseInteraction()
    {
        interactionCount++;
    }

    // Method to return the interaction count
    public int GetInteractionCount()
    {
        return interactionCount;
    }

    // Method to return the knowledge level
    public KnowledgeLevel GetKnowledgeLevel()
    {
        return knowledgeLevel;
    }

    // Method to set a specific knowledge level
    public void SetKnowledgeLevel(KnowledgeLevel level)
    {
        knowledgeLevel = level;
    }

    // Method to get the sprite of the item
    public Sprite GetSprite()
    {
        return itemSprite;
    }

    // Method to set the sprite of the item
    public void SetSprite(Sprite sprite)
    {
        itemSprite = sprite;
    }
}
