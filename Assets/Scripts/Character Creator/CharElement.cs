using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharElement
{
    public int numShapes; // Total number of shapes
    public int numSwatches; // Number of swatches (e.g., hair colors)
    public int curIndex; // Current index, used for saving to JSON
    public string element; // Name of the element (e.g., "Hair", "Eyes")
    public string PNG; // Path to the sprite sheet
    public SpriteRenderer render; // Sprite renderer for the element
    public bool isModified; // Tracks if the element has been modified

    // Default constructor
    public CharElement()
    {
        numShapes = 0;
        numSwatches = 0;
        curIndex = 0;
        element = "Default";
        PNG = string.Empty;
        render = null;
        isModified = false;
    }

    // Custom constructor
    public CharElement(int numShapes, int numSwatches, int curIndex, string element, string PNG, SpriteRenderer render)
    {
        this.numShapes = Mathf.Max(0, numShapes); // Ensure non-negative values
        this.numSwatches = Mathf.Max(0, numSwatches);
        this.curIndex = Mathf.Max(0, curIndex);
        this.element = element ?? "Unnamed Element"; // Default name if null
        this.PNG = PNG ?? string.Empty; // Default path if null
        this.render = render;
        this.isModified = false;
    }

}
