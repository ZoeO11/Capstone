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

    public void Start()
    {
        _title.gameObject.SetActive(false);
        speechBubble.SetActive(false);
        ExPoint.SetActive(false);
        if (GameManager.playerData.char1_list.Count > 0)
        {
            ExPoint.SetActive(true);
            
        }

    }
    void OnMouseDown()
    {
        ExPoint.SetActive(false);
        _title.gameObject.SetActive(true);
        speechBubble.SetActive(true);
        _title.text = GameManager.playerData.char1_list[0];
    }
}