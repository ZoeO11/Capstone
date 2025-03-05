using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ClickableObject : ScriptableObject
{
    public string objectName;
    public int interaction_count;
    public NPC character_for_KC;
    public int knowledgeLevel;
    public bool inKnowledgeCheck;
}
