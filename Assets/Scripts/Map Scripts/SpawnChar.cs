using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChar : MonoBehaviour
{
    [Header("Character Settings")]
    public GameObject[] characterPrefabs; // Array of character prefabs to spawn
    public int numberOfCharacters = 10;   // Total number of characters to spawn

    [Header("Spawn Area Settings")]
    public float xMin = -10f;             // Minimum x-coordinate for spawning
    public float xMax = 10f;              // Maximum x-coordinate for spawning
    public float zPosition = 0f;          // Fixed z-coordinate for spawning
    public float yPosition = 0f;          // Fixed y-coordinate for spawning

    [Header("Spacing Settings")]
    public float minSpacing = 1.5f;       // Minimum spacing between characters

    private void Start()
    {
        SpawnCharacters();
    }

    private void SpawnCharacters()
    {
        // List of already used x-coordinates to enforce spacing
        System.Collections.Generic.List<float> usedXPositions = new System.Collections.Generic.List<float>();

        for (int i = 0; i < numberOfCharacters; i++)
        {
            // Randomly select a character prefab
            GameObject characterPrefab = characterPrefabs[Random.Range(0, characterPrefabs.Length)];

            // Find a valid x-position with sufficient spacing
            float xPosition;
            int attempts = 0;
            do
            {
                xPosition = Random.Range(xMin, xMax);
                attempts++;
            }
            while (!IsPositionValid(xPosition, usedXPositions) && attempts < 100);

            // Add the x-position to the list if valid
            if (attempts < 100)
            {
                usedXPositions.Add(xPosition);

                // Spawn the character at the selected position
                Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);
                Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    private bool IsPositionValid(float xPosition, System.Collections.Generic.List<float> usedXPositions)
    {
        foreach (float usedX in usedXPositions)
        {
            if (Mathf.Abs(xPosition - usedX) < minSpacing)
                return false;
        }
        return true;
    }
}

