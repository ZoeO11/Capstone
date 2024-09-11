using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;  // For file management

public class MainMenu : MonoBehaviour
{
    private string savePath1;
    private string savePath2;

    void Start()
    {
        // Define paths to the save files
        savePath1 = Application.persistentDataPath + "/game1Save.json";
        savePath2 = Application.persistentDataPath + "/game2Save.json";
    }

    public void StartGame1()
    {
        if (File.Exists(savePath1))  // Check if save data for Game1 exists
        {
            // Load Game1 from the last saved location
            LoadGame(savePath1, "Game1");
        }
        else
        {
            // Start a new game in the character creation scene
            SceneManager.LoadScene("CharCreation");
        }
    }

    public void StartGame2()
    {
        if (File.Exists(savePath2))  // Check if save data for Game2 exists
        {
            // Load Game2 from the last saved location
            LoadGame(savePath2, "Game2");
        }
        else
        {
            // Start a new game in the character creation scene
            SceneManager.LoadScene("CharCreation");
        }
    }

    public void GoToCharCreation()
    {
        // Allow the player to return to the character creation scene from the game
        SceneManager.LoadScene("CharCreation");
    }

    public void SaveGame1(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath1, json);
        Debug.Log("Game1 saved");
    }

    public void SaveGame2(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath2, json);
        Debug.Log("Game2 saved");
    }

    void LoadGame(string savePath, string sceneName)
    {
        // Read the save data from the file
        string json = File.ReadAllText(savePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        // Apply loaded data (for example, setting player attributes based on saved data)
        Debug.Log("Loaded game for " + data.playerName);

        // Now proceed to the saved game scene
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OpenPreferences()
    {
        SceneManager.LoadScene("Preferences");
    }
}
