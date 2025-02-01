using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    // Reference to the CharCreate script
    public CharCreate characterCreate;

    // Index of the selected hair color
    private int hairColorIndex;

    // This method is called when a color selection object is clicked
    private void OnMouseDown()
    {
        // Ensure the characterCreate reference is set
        if (characterCreate == null)
        {
            Debug.LogError("CharCreate reference is not set in the ColorSelector script!");
            return;
        }

        // Try to convert the object's name to an integer
        if (int.TryParse(gameObject.name, out hairColorIndex))
        {
            // If successful, update the pHairColor in the CharCreate script
            characterCreate.pHairColor = hairColorIndex;
            characterCreate.ChangeHairColor(); // Update the hair color
        }
        else
        {
            // If the object's name is not an integer, print a warning
            Debug.LogWarning($"Object name '{gameObject.name}' is not a valid integer.");
        }
    }
}
