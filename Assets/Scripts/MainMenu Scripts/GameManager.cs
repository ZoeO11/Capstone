using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private string currentGame;
    private Dictionary<string, bool> playedGames = new Dictionary<string, bool>();
    public static PlayerData playerData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Removed player data loading from Start() method
    void Start()
    {
        // Leave empty or set default state if needed
    }

    // Load player data only after the game has been selected
    public void SetCurrentGame(string game)
    {
        currentGame = game;

        // Try to load player data for the selected game
        playerData = SaveSystem.LoadPlayerData(currentGame);

        // If no player data exists, initialize it for a new game
        if (playerData == null)
        {
            Debug.Log("No player data found, initializing new game...");
            playerData = new PlayerData();  // Initialize a new PlayerData object
        }
        else
        {
            Debug.Log("Player data loaded successfully.");
        }
    }

    public string GetCurrentGame()
    {
        return currentGame;
    }

    public bool HasPlayedGame(string game)
    {
        return playedGames.ContainsKey(game) && playedGames[game];
    }
}
