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

    // vocab list for save file
    public List<VocabularyEntry> vocabulary_list = new List<VocabularyEntry>();

    // char1 list
    public List<string> char1_list = new List<string>();
    // char2 list
    public List<string> char2_list = new List<string>();
    // char 3 list
    public List<string> char3_list = new List<string>();
    // char4 list
    public List<string> char4_list = new List<string>();


}

[System.Serializable] // this is necessary so that it can be serialized
public class VocabularyEntry
{
    public string word;
    public KnowledgeLevel knowledgeLevel;
    public int interactionCount;

    public VocabularyEntry(string word, KnowledgeLevel level)
    {
        this.word = word;
        this.knowledgeLevel = level;
        this.interactionCount = 0;

    }
}