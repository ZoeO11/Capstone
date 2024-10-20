using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour
{
    public void StartGame1()
    {

        // check if the playerData save file for game 1 (game1.save) exists
        if (SaveSystem.LoadPlayerData("game1") != null) {

            Debug.Log("Game 1 already exists :)");
            GameManager.instance.SetCurrentGame("game1");
            SceneManager.LoadScene("Home");

        }
        else
        {
            Debug.Log("Game 1 does not exist. Launching...");

            // error with the following line. the dictionary is NOT getting updated properly
            GameManager.instance.SetGamePlayed("game1");

            GameManager.instance.SetCurrentGame("game1");
            SceneManager.LoadScene("CharCreation");
        }
    }

    public void StartGame2()
    {
        // check if the playerData save file for game 1 (game1.save) exists
        if (SaveSystem.LoadPlayerData("game2") != null)
        {

            Debug.Log("Game 2 already exists :)");
            GameManager.instance.SetCurrentGame("game1");
            SceneManager.LoadScene("Home");

        }
        else
        {
            Debug.Log("Game 2 does not exist. Launching...");

            // error with the following line. the dictionary is NOT getting updated properly
            GameManager.instance.SetGamePlayed("game2");

            GameManager.instance.SetCurrentGame("game2");
            SceneManager.LoadScene("CharCreation");
        }
    }

}
