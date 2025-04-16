using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickableObjectsHandler : MonoBehaviour
{ 
    public GeneralObject myObject;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false; // We want to trigger it manually
    }
    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("DisplayText") != null)
        {
            GameObject displayObj = GameObject.FindGameObjectWithTag("DisplayText");
            TextMeshProUGUI tmp = displayObj.GetComponent<TextMeshProUGUI>();
            Color originalColor = tmp.color;
            originalColor.a = 0f; // Set alpha to 0
            tmp.color = originalColor;
            //panel.gameObject.SetActive(false);
        }
    }
    public void OnMouseDown()
    {
        if (myObject != null && myObject.audioClip != null)
        {
            Debug.Log($"Playing audio for: {myObject.objectName}");
            audioSource.clip = myObject.audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clip assigned in ScriptableObject.");
        }
        if (GameObject.FindGameObjectWithTag("DisplayText") != null)
        {
            GameObject displayObj = GameObject.FindGameObjectWithTag("DisplayText");
            TextMeshProUGUI tmp = displayObj.GetComponent<TextMeshProUGUI>();
            Color originalColor = tmp.color;
            originalColor.a = 1f;
            tmp.color = originalColor;

            StartCoroutine(HideTextAfterDelay(3f, tmp));
            //panel.gameObject.SetActive(true);
            tmp.text = myObject.name;
        }
        if (myObject.inKnowledgeCheck){
            if (myObject is ClickableObject)
            {
                myObject.knowledgeLevel++;
                myObject.interaction_count++;
                myObject.inKnowledgeCheck = false;
            }   
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
                myObject.inKnowledgeCheck = true;
            }

        }
        else if (myObject.interaction_count == 10)
        {

            if (!myObject.character_for_KC.kc_list.Contains(myObject))
            {
                myObject.character_for_KC.kc_list.Add(myObject);
                myObject.inKnowledgeCheck = true;
            }

        }
        else if (myObject.interaction_count == 15)
        {

            if (!myObject.character_for_KC.kc_list.Contains(myObject))
            {
                myObject.character_for_KC.kc_list.Add(myObject);
                myObject.inKnowledgeCheck = true;
            }
        }
        else
        {
            myObject.interaction_count++;
        }
    }
    public IEnumerator HideTextAfterDelay(float delay, TextMeshProUGUI tmp)
    {
        yield return new WaitForSeconds(delay);
        Color color = tmp.color;
        color.a = 0f;
        tmp.color = color;
    }
}
            



