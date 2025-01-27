using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private PlayerData playerData;
    private ClickableItems plant;
    private int wordExists;
    private int interaction_count;
    Animator anim;
    public string character_for_KC;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());
        plant = new ClickableItems("plant");
        plant.character_for_KC = "char1";
        plant.GetPrevValues(playerData);
        SaveSystem.clickableObjectsList.Add(plant);
    }
    void OnMouseDown()
    {
        anim.SetTrigger("onclickanimate");
        Debug.Log("PLANT CLICKED");
        plant.ChangeKnowledgeLevel(playerData, plant.character_for_KC);
    }
}
    