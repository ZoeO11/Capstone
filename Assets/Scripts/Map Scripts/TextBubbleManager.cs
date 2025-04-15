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
    public string task;
    public SpriteRenderer verb;
    public SpriteRenderer noun;

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
        if(myNPC.kc_list[0] is ClickableObject)
        {
            if (myNPC.kc_list[0].knowledgeLevel == 1)
            {
                Sprite find = Resources.Load<Sprite>("Map/magnifying");
                verb.sprite = find;
                noun.sprite = myNPC.kc_list[0].icon;
            }
            else if (myNPC.kc_list[0].knowledgeLevel == 2)
            {
                Sprite find = Resources.Load<Sprite>("Map/magnifying");
                verb.sprite = find;
                noun.sprite = myNPC.kc_list[0].icon;
                task = $"Find the {myNPC.kc_list[0].name}.";
                _title.text = task;
                _title.gameObject.SetActive(true);
            }
            else
            {
                task = $"Find the {myNPC.kc_list[0].name}.";
                _title.text = task;
                _title.gameObject.SetActive(true);
            }
        }
        if (myNPC.kc_list[0] is MoveableObject)
        {
            if (myNPC.kc_list[0].knowledgeLevel == 1)
            {
                Sprite bring = Resources.Load<Sprite>("SpriteExamples/rock");
                verb.sprite = bring;
                noun.sprite = myNPC.kc_list[0].icon;
            }
            else
            {
                task = $"Bring me the {myNPC.kc_list[0].name}.";
                _title.text = task;
                _title.gameObject.SetActive(true);
            }
        }
        _title.text = task;
        myNPC.kc_list[0].inKnowledgeCheck = true;
    }
    

}