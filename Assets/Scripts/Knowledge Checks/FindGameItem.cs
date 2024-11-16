using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class FindGameItem : MonoBehaviour
{
    public Button[] answerButtons;

    private int attempts = 0;

    // The method that is called to load the knowledge check
    public int LoadFindItemKC(GameItem gameItem, PlayerData playerData)
    {
        Debug.Log("Inside LoadFindItemKC function...");

        string current_scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Knowledge Check 1");

        // Load correct sprite for the gameItem
        Sprite correctSprite = Resources.Load<Sprite>("TextMesh Pro/Resources/Sprites/" + gameItem.objectName);

        if (correctSprite == null)
        {
            Debug.LogError($"Sprite not found for {gameItem.objectName} in Sprites folder!");
            return -1;
        }

        // Get all available sprites
        Sprite[] allSprites = Resources.LoadAll<Sprite>("TextMesh Pro/Resources/Sprites");
        List<Sprite> distractors = new List<Sprite>();

        // Exclude the correct sprite
        foreach (Sprite sprite in allSprites)
        {
            if (sprite.name != gameItem.objectName)
            {
                distractors.Add(sprite);
            }
        }

        // Pick 3 random distractor sprites
        List<Sprite> selectedSprites = new List<Sprite> { correctSprite };
        while (selectedSprites.Count < 4 && distractors.Count > 0)
        {
            int randomIndex = Random.Range(0, distractors.Count);
            selectedSprites.Add(distractors[randomIndex]);
            distractors.RemoveAt(randomIndex);
        }

        // Shuffle the sprites to randomize their placement
        Shuffle(selectedSprites);

        // Assign sprites to buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i];
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.sprite = selectedSprites[i];

            // Reset listener before adding new one to avoid duplication
            button.onClick.RemoveAllListeners();

            // Assign correct or incorrect logic
            if (selectedSprites[i] == correctSprite)
            {
                button.onClick.AddListener(() => CorrectAnswer(current_scene, gameItem, playerData));
            }
            else
            {
                button.onClick.AddListener(() => IncorrectAnswer());
            }
        }

        // Return the number of attempts (could be used for tracking or feedback)
        return attempts;
    }

    private void CorrectAnswer(string previousScene, GameItem gameItem, PlayerData playerData)
    {
        Debug.Log("Correct answer!");

        // Return to the previous scene
        SceneManager.LoadScene(previousScene);

    }

    private void IncorrectAnswer()
    {
        attempts++; // Increment the attempt counter
        Debug.Log("Incorrect answer. Attempt: " + attempts);

        // Additional game logic (e.g., give feedback or penalize player)
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
