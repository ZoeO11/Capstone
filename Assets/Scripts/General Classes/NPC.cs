using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu]
public class NPC : ScriptableObject
{
    public List<GeneralObject> kc_list = new List<GeneralObject>();
    public Collider2D myCollider;
    public TMP_Text myText;
}