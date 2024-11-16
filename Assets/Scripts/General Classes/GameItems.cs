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
    public Sprite itemSprite;

    // Constructor to initialize an object
    public GameItem(string name)
    {
        objectName = name;
        knowledgeLevel = KnowledgeLevel.HAS_NOT_SEEN;
        interactionCount = 0;  // Initially set interaction count to 0
    }

    // Method to update the knowledge level based on interaction count
    public void IncreaseInteraction()
    {

        interactionCount += 1;
        
    }

    public int GetInteractionCount()
    {
        return interactionCount;
    }

    public KnowledgeLevel GetKnowledgeLevel()
    {
        return knowledgeLevel;
    }

    public void SetKnowledgeLevel(KnowledgeLevel level)
    {
        knowledgeLevel = level;
    }

    public Sprite GetSprite()
    {
        return itemSprite;
    }

    public void SetSprite(Sprite sprite)
    {
        itemSprite = sprite;
    }

}