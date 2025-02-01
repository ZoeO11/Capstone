using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public string playerGender;
    public string nativeLanguage;
    public string targetLanguage;
    public int hairStyleIndex;
    public int hairColorIndex;

    // Vocab list for save file
    public List<VocabularyEntry> vocabulary_list = new List<VocabularyEntry>();

    public List<string> tasks = new List<string>();

    // Character-specific lists
    public List<string> char1_list = new List<string>();
    public List<string> char2_list = new List<string>();
    public List<string> char3_list = new List<string>();
    public List<string> char4_list = new List<string>();

    // **Singleton-like static instance**
    public static PlayerData Instance { get; private set; }

    public static void Initialize(string gameName)
    {
        // Load player data or create new instance
        Instance = SaveSystem.LoadPlayerData(gameName) ?? new PlayerData();
    }

    public static void Save(string gameName)
    {
        if (Instance != null)
        {
            SaveSystem.SavePlayerData(Instance, gameName);
        }
    }
}

[System.Serializable] // This is necessary so that it can be serialized
public class VocabularyEntry
{
    public string word;
    public KnowledgeLevel knowledgeLevel;
    public int interactionCount;

    public VocabularyEntry(string word, int interaction_count, KnowledgeLevel level)
    {
        this.word = word;
        this.knowledgeLevel = level;
        this.interactionCount = interaction_count;
    }
}
