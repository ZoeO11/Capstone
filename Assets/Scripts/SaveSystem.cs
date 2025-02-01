using System.IO;
using UnityEngine;

public class SaveSystem
{
    // Save PlayerData to a file
    public static void SavePlayerData(PlayerData playerData, string gameName)
    {
        string path = Application.persistentDataPath + "/" + gameName + ".save";
        string json = JsonUtility.ToJson(playerData, true); // Pretty-print for readability
        File.WriteAllText(path, json);
    }

    // Load PlayerData from a file
    public static PlayerData LoadPlayerData(string gameName)
    {
        string path = Application.persistentDataPath + "/" + gameName + ".save";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<PlayerData>(json);
        }
        return null;
    }
}