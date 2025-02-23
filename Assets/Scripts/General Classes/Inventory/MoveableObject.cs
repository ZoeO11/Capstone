using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MoveableObject : ScriptableObject
{
    public string objectName;
    public Sprite icon;
    public bool wordExistsInVocab;
    public int indexInVocab;
    public int interaction_count;
    public string character_for_KC;
    public GameObject prefab;
}
