using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Object
{

    // enum to represent the possible knowledge levels
    public enum KnowledgeLevel
    {
        HAS_NOT_SEEN,
        LEVEL_1,
        LEVEL_2,
        LEVEL_3
    }

    public string objectName;   // the name of the object (ex: chair, apple)
    public Vector3 position;    // position of the object in the game world
    public KnowledgeLevel knowledgeLevel;   // user's knowledge level of the object 

    // constructor to initialize an object with values
    public Object(string name, Vector3 pos)
    {
        objectName = name;
        position = pos;
        knowledgeLevel = KnowledgeLevel.HAS_NOT_SEEN;
    }
}