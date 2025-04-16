using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObject : ScriptableObject
{
    public Sprite icon;
    public string objectName;
    public int interaction_count;
    public int knowledgeLevel;
    public bool inKnowledgeCheck;
    public bool kcStarted;
    public NPC character_for_KC;
    public AudioClip audioClip;

}
