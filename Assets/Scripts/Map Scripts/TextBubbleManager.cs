using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBubbleManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _title;


    public void Start()
    {
        PlayerData playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());
        _title.text = playerData.char1_list[0];
    }
}