using UnityEngine;
using System.Collections.Generic;
using System.IO;


// This script handles global game data, such as which game
// is currently being played and whether a game has already been started


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private string currentGame;
    private Dictionary<string, bool> playedGames = new Dictionary<string, bool>();

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

    public void SetCurrentGame(string game)
    {
        currentGame = game;
    }

    public string GetCurrentGame()
    {
        return currentGame;
    }

    public bool HasPlayedGame(string game)
    {
        return playedGames.ContainsKey(game) && playedGames[game];
    }

    public void SetGamePlayed(string game)
    {

        instance.playedGames[game] = true;  // Add new game
    }

}
