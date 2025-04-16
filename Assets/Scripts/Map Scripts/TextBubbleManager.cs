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
    public Sprite empty;
    public GeneralObject currentObject;
    public SpriteRenderer exRen;

    public void Start()
    {
        _title.gameObject.SetActive(false);
        speechBubble.SetActive(false);
        exRen = gameObject.GetComponent<SpriteRenderer>();
        exRen.enabled = false;

        if (myNPC.kc_list.Count > 0)
        {
            exRen.enabled = true;
            //ExPoint.SetActive(true);

        }

    }
    public void Update()
    {
        if (myNPC.kc_list.Count > 0)
        {
            if (!myNPC.kc_list[0].inKnowledgeCheck)
            {
                Debug.Log("reached!");
                verb.enabled = false;
                noun.enabled = false;
                currentObject = myNPC.kc_list[0];
                myNPC.kc_list.Remove(currentObject);
            }
        }
    }
    void OnMouseDown()
    {
        if (exRen.enabled)
        {
            exRen.enabled = false;
            _title.gameObject.SetActive(true);
            speechBubble.SetActive(true);
            verb.enabled = true;
            noun.enabled = true;
            if (myNPC.kc_list.Count > 0)
            {
                if (myNPC.kc_list[0] is ClickableObject)
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
                        Sprite bring = Resources.Load<Sprite>("NPCs/linda/bring-07");
                        verb.sprite = bring;
                        noun.sprite = myNPC.kc_list[0].icon;
                    }
                    else if (myNPC.kc_list[0].knowledgeLevel == 2)
                    {
                        Sprite find = Resources.Load<Sprite>("NPCs/linda/bring-07");
                        verb.sprite = find;
                        noun.sprite = myNPC.kc_list[0].icon;
                        task = $"Bring me the {myNPC.kc_list[0].name}.";
                        _title.text = task;
                        _title.gameObject.SetActive(true);
                    }
                    else
                    {
                        verb.enabled = false;
                        noun.enabled = false;
                        task = $"Bring me the {myNPC.kc_list[0].name}.";
                        _title.text = task;
                        _title.gameObject.SetActive(true);
                    }
                }
                _title.text = task;
                myNPC.kc_list[0].inKnowledgeCheck = true;
            }
        }
    }
    }
    

