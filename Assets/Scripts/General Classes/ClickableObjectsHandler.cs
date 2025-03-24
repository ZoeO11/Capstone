using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickableObjectsHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;
    public GeneralObject myObject;
    public GameObject panel;
    // Start is called before the first frame update
    public void Start()
    {
        _title.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        _title.gameObject.SetActive(true);
        panel.gameObject.SetActive(true);
        _title.text = myObject.name;
        if (myObject.inKnowledgeCheck){
            myObject.knowledgeLevel++;
            myObject.interaction_count++;
            myObject.inKnowledgeCheck = false;
        }
        else if (myObject.interaction_count == 1)
        {
            myObject.knowledgeLevel = 1;
            myObject.interaction_count++;
        }

        else if (myObject.interaction_count == 5)
        {
            if (!myObject.character_for_KC.kc_list.Contains(myObject))
            {
                myObject.character_for_KC.kc_list.Add(myObject);
            }

        }
        else if (myObject.interaction_count == 13)
        {

            if (!myObject.character_for_KC.kc_list.Contains(myObject))
            {
                myObject.character_for_KC.kc_list.Add(myObject);
            }

        }
        else
        {
            myObject.interaction_count++;
        }
    }


}
