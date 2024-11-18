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
    void Start()
    {
        anim = GetComponent<Animator>();
        playerData = SaveSystem.LoadPlayerData(GameManager.instance.GetCurrentGame());
        plant = new ClickableItems("plant");
        plant.GetPrevValues(playerData);
        SaveSystem.clickableObjectsList.Add(plant);
    }
    void OnMouseDown()
    {
        anim.SetTrigger("onclickanimate");
        Debug.Log("PLANT CLICKED");
        plant.ChangeKnowledgeLevel();
    }
}
    