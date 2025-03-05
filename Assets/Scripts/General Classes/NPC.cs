using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NPC : ScriptableObject
{
    public List<ClickableObject> kc_list = new List<ClickableObject>();
}