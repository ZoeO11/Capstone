using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BackButton : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        backButton.onClick.AddListener(HandleBackButton);
    }

    void HandleBackButton()
    {
        // Save player data when the back button is clicked
        SaveSystem.SavePlayerData(GameManager.playerData, GameManager.instance.GetCurrentGame());
        Debug.Log("Player data saved.");
        SceneManager.LoadScene("Map");
    }
}
