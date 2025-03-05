using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBubbleManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;
    public GameObject speechBubble;
    public GameObject ExPoint;
    public NPC myNPC;

    public void Start()
    {
        _title.gameObject.SetActive(false);
        speechBubble.SetActive(false);
        ExPoint.SetActive(false);

        if (myNPC.kc_list.Count > 0)
        {
            ExPoint.SetActive(true);
            
        }

    }
    void OnMouseDown()
    {
        ExPoint.SetActive(false);
        _title.gameObject.SetActive(true);
        speechBubble.SetActive(true);
        string task = $"Find the {myNPC.kc_list[0].name}.";
        _title.text = task;
        myNPC.kc_list[0].inKnowledgeCheck = true;
    }
}