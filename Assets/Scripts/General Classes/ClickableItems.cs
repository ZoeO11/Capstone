using UnityEngine;

public class ClickableItems : GameItem
{
    public bool isClickable;
    public bool wordExistsInVocab;
    public int indexInVocab;

    // Constructor
    public ClickableItems(string name) : base(name)
    {
        isClickable = true;
        objectName = name;
    }

    public int CheckIfWordExistsInVocab(PlayerData playerData)
    {
        for (int i = 0; i < playerData.vocabulary_list.Count; i++)
        {
            if (playerData.vocabulary_list[i].word == objectName)
            {
                return i; // Return the index of the word if found
            }
        }

        // If the word isn't found, return -1
        return -1;
    }

}


