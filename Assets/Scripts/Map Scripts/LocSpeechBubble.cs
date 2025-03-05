using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocSpeechBubble : MonoBehaviour
{
   
    public TMP_Text _title;
    public GameObject speechBubble;
    public NPC myNPC;
    public ClickableObject currentObject;

    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.SetActive(false);
        _title.gameObject.SetActive(false);
        speechBubble.SetActive(false);
        if (myNPC.kc_list.Count > 0)
        {
            if (myNPC.kc_list[0].inKnowledgeCheck)
            {
                currentObject = myNPC.kc_list[0];
                gameObject.SetActive(true);
                _title.gameObject.SetActive(true);
                speechBubble.SetActive(true);
                _title.text = $"Find the {myNPC.kc_list[0].name}.";
            }

        }

    }
    private void Update()
    {
        if (myNPC.kc_list.Count > 0)
        {
            if (!myNPC.kc_list[0].inKnowledgeCheck)
            {
                _title.text = "Thank you!";
                myNPC.kc_list.Remove(currentObject);
                currentObject = null;

            }
        }
        }
    }
