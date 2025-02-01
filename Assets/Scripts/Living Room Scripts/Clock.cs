using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private ClickableItems clock;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        clock = new ClickableItems("clock");
        clock.character_for_KC = "char1";

        clock.GetPrevValues();
        
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        anim.SetTrigger("onclickanimate");
        Debug.Log("CLOCK CLICKED");

        clock.ChangeKnowledgeLevel(clock.character_for_KC);

        clock.UpdateVocabularyList();
    }
}
