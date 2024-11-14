using UnityEngine;
using System.Collections;

public class TouchDrawer : MonoBehaviour
{
    public GameObject linePrefab; // Prefab containing a LineRenderer component
    public Color drawColor = Color.black; // Default draw color
    public float brushSize = 0.1f; // Default brush size
    Coroutine drawing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsMouseOnCanvas())
        {
            StartLine();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            FinishLine();
        }
    }

    void StartLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
        }
        drawing = StartCoroutine(DrawLine());
    }

    void FinishLine()
    {
        if (drawing != null)
        {
            StopCoroutine(drawing);
            drawing = null; // Clear the reference after stopping the coroutine
        }
    }

    IEnumerator DrawLine()
    {
        // Instantiate a new line from the prefab
        GameObject lineObject = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        LineRenderer line = lineObject.GetComponent<LineRenderer>();

        // Set the initial properties for the line
        line.startColor = drawColor;
        line.endColor = drawColor;
        line.startWidth = brushSize;
        line.endWidth = brushSize;
        line.positionCount = 0;

        // Drawing loop
        while (true)
        {
            if (!IsMouseOnCanvas()) break; // Stop drawing if the mouse moves out of the canvas

            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0; // Ensure the line is at the correct depth
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, position);
            yield return null;
        }
    }

    bool IsMouseOnCanvas()
    {
        // Convert the mouse position to world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-position matches the canvas plane

        // Check if there is a collider at the mouse position and it's the canvas
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
        return hitCollider != null && hitCollider.gameObject == gameObject; // Ensure the hit object is the current GameObject (the canvas)
    }
}
