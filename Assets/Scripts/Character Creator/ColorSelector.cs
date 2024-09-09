using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    // Reference to the CharCreate script
    public CharCreate characterCreate;
    public int hairColorIndex;
    // This method is called when a color selection object is clicked on
    void OnMouseDown()
    {
        // Try to convert the object's name to an integer
        
        if (int.TryParse(gameObject.name, out hairColorIndex))
        {
            // If successful, set the PHairColor in the CharCreate script
            characterCreate.PHairColor = hairColorIndex;
        }
        else
        {
            // If the object's name is not an integer, print a warning
            Debug.LogWarning("Object name is not a valid integer: " + gameObject.name);
        }
        characterCreate.ChangeHairColor(); 
    }
}
