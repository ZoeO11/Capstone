using System.IO;
using UnityEngine;

// The Save class will handle saving and loading playerData to and from files.
// This ensures data persistence between sessions.


public static class SaveSystem
{
    public static void SavePlayerData(PlayerData playerData, string gameName)
    {
        string path = Application.persistentDataPath + "/" + gameName + ".save";
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, json);
    }

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
