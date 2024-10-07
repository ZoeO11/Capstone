using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Object
{
    public enum KnowledgeLevel
    {
        HAS_NOT_SEEN,
        LEVEL_1,
        LEVEL_2,
        LEVEL_3
    }

    public string objectName;   // Name of the object
    public Vector3 position;    // Position of the object in the game world
    public KnowledgeLevel knowledgeLevel;   // User's knowledge level of the object 
    public int interactionCount;  // Track how many times the object has been interacted with

    // Constructor to initialize an object
    public Object(string name, Vector3 pos)
    {
        objectName = name;
        position = pos;
        knowledgeLevel = KnowledgeLevel.HAS_NOT_SEEN;
        interactionCount = 0;  // Initially set interaction count to 0
    }

    // Method to update the knowledge level based on interaction count
    public void UpdateKnowledgeLevel()
    {
        if (interactionCount > 20)
        {
            knowledgeLevel = KnowledgeLevel.LEVEL_3;
        }
        else if (interactionCount > 10)
        {
            knowledgeLevel = KnowledgeLevel.LEVEL_2;
        }
        else if (interactionCount > 0)
        {
            knowledgeLevel = KnowledgeLevel.LEVEL_1;
        }
    }
}