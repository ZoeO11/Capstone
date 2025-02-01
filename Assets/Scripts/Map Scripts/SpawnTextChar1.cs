using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTextChar1 : MonoBehaviour
{

    static PlayerData playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());

    static List<string> desired_char_list = playerData.char1_list;

    string go_find_text = desired_char_list[0];


}
