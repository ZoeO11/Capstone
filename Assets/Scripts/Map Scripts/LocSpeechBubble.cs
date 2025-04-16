using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocSpeechBubble : MonoBehaviour
{
   
    public TMP_Text _title;
    public GameObject speechBubble;
    public NPC myNPC;
    public GeneralObject currentObject;
    public SpriteRenderer verb;
    public SpriteRenderer noun;

    // Start is called before the first frame update
    void Start()
    {
        verb.enabled = false;
        noun.enabled = false;
        gameObject.SetActive(false);
        _title.gameObject.SetActive(false);
        speechBubble.SetActive(false);
        if (myNPC.kc_list.Count > 0)
        {
            if (myNPC.kc_list[0].kcStarted && myNPC.kc_list[0] is ClickableObject)
            {
                currentObject = myNPC.kc_list[0];
                gameObject.SetActive(true);

                
                if (myNPC.kc_list[0].knowledgeLevel == 1)
                {
                    verb.enabled = true;
                    noun.enabled = true;
                    speechBubble.SetActive(true);
                    Sprite find = Resources.Load<Sprite>("Map/magnifying");
                    verb.sprite = find;
                    noun.sprite = myNPC.kc_list[0].icon;
                }
                else if (myNPC.kc_list[0].knowledgeLevel == 2)
                {
                    verb.enabled = true;
                    noun.enabled = true;
                    Sprite find = Resources.Load<Sprite>("Map/magnifying");
                    verb.sprite = find;
                    noun.sprite = myNPC.kc_list[0].icon;
                    _title.gameObject.SetActive(true);
                    speechBubble.SetActive(true);
                    _title.text = $"Encuentra {myNPC.kc_list[0].name}.";
                }
                else
                {
                    _title.gameObject.SetActive(true);
                    speechBubble.SetActive(true);
                    _title.text = $"Encuentra {myNPC.kc_list[0].name}.";
                }
            }

        }

    }
    private void Update()
    {
        if (myNPC.kc_list.Count > 0)
        {
            if (!myNPC.kc_list[0].inKnowledgeCheck && myNPC.kc_list[0] is ClickableObject)
            {
                verb.enabled = false;
                noun.enabled = false;
                _title.gameObject.SetActive(true);
                _title.text = "Gracias!";
                myNPC.kc_list.Remove(currentObject);
                currentObject = null;

            }
        }
        }
    }
