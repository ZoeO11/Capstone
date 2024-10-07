using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;  // For file management

public class MainMenu : MonoBehaviour
{
    private string savePath1;
    private string savePath2;
    private SaveData playerData;  // Store the player's data here
    public GameObject mainMenuPrefab; // Declare mainMenuPrefab
    public GameObject mainMenuUI;  // Declare the main menu UI
    public static MainMenu Instance { get; private set; }  // Singleton instance

    void Start()
    {
        // Define paths to the save files
        savePath1 = Application.persistentDataPath + "/game1Save.json";
        savePath2 = Application.persistentDataPath + "/game2Save.json";
    }

    private void Awake()
    {
        // Ensure only one instance of MainMenu exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Keep this object across scenes
        Debug.Log("MainMenu instance created");
    }

    public void StartGame1()
    {
        if (File.Exists(savePath1))  // Check if save data for Game1 exists
        {
            // Disable the main menu UI
            mainMenuUI.SetActive(false);
            LoadGame(savePath1, "Game1");
        }
        else
        {
            mainMenuUI.SetActive(false);  // Disable the menu UI when starting a new game
            SceneManager.LoadScene("CharCreation");
        }
    }

    public void StartGame2()
    {
        if (File.Exists(savePath2))  // Check if save data for Game2 exists
        {
            mainMenuUI.SetActive(false);  // Disable the menu UI
            LoadGame(savePath2, "Game2");
        }
        else
        {
            mainMenuUI.SetActive(false);  // Disable the menu UI when starting a new game
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

    public void SaveGame1Caller()
    {
        if (playerData != null)
        {
            SaveGame1(playerData); // Call the existing method with playerData
        }
        else
        {
            Debug.LogWarning("Player data is null! Cannot save game.");
        }
    }

    public void SaveGame2Caller()
    {
        if (playerData != null)
        {
            SaveGame2(playerData); // Call the existing method with playerData
        }
        else
        {
            Debug.LogWarning("Player data is null! Cannot save game.");
        }
    }


    void LoadGame(string savePath, string sceneName)
    {
        // Read the save data from the file
        string json = File.ReadAllText(savePath);
        playerData = JsonUtility.FromJson<SaveData>(json);  // Store the loaded data

        // Apply loaded data (for example, setting player attributes based on saved data)
        Debug.Log("Loaded game for " + playerData.playerName);

        // Now proceed to the saved game scene
        SceneManager.LoadScene(sceneName);
    }

    public SaveData GetPlayerData()
    {
        return playerData;  // Access the loaded player data
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
