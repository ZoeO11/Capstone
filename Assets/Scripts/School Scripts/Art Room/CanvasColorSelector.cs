using UnityEngine;

public class CanvasColorSelector : MonoBehaviour
{
    public Color color; // Assign the color in the Inspector

    // Reference to the TouchDrawer script (assuming it's attached to the Canvas)
    private TouchDrawer touchDrawer;

    private void Start()
    {
        // Find the TouchDrawer script in the scene
        touchDrawer = FindObjectOfType<TouchDrawer>();
        if (touchDrawer == null)
        {
            Debug.LogError("TouchDrawer script not found in the scene!");
        }
    }

    private void OnMouseDown()
    {
        if (touchDrawer != null)
        {
            touchDrawer.drawColor = color; // Change the drawing color
        }
    }
}
