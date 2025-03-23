using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveableObject : ScriptableObject
{
    public string objectName;
    public Sprite icon;
    public int interaction_count;
    public NPC character_for_KC;
    public int knowledgeLevel;
    public bool inKnowledgeCheck;
    public GameObject prefab;
}
