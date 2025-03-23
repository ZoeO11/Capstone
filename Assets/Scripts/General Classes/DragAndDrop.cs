using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false; // Track if object is being dragged
    private Vector3 offset; // Offset between mouse position and object position
    private Rigidbody2D rb; // Reference to Rigidbody2D component
    private Collider2D col; // Reference to Collider2D component
    private float originalScale; // Store the original scale of the object
    private float rotationSpeed = 10f; // Speed of oscillation rotation
    private float rotationAngle = 5f; // Maximum rotation angle in degrees
    private float timeElapsed = 0f; // Time tracker for oscillation

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
        col = GetComponent<Collider2D>();  // Get Collider2D component
        originalScale = transform.localScale.x; // Store the initial scale of the object
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If mouse is clicked
            TryStartDrag(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0) && isDragging) // If dragging with mouse
        {
            DragObject(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            AnimateDragging(); // Apply animation while dragging
        }

        if (Input.GetMouseButtonUp(0)) // If mouse button is released
            StopDrag();

        // Handle touch input for mobile devices
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began) // If touch begins
                TryStartDrag(touchPos);

            if (touch.phase == TouchPhase.Moved && isDragging) // If dragging with touch
            {
                DragObject(touchPos);
                AnimateDragging();
            }

            if (touch.phase == TouchPhase.Ended) // If touch ends
                StopDrag();
        }
    }

    void TryStartDrag(Vector3 inputPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(inputPosition, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            offset = transform.position - inputPosition; // Calculate offset to maintain relative position

            // Disable physics while dragging
            if (rb != null)
            {
                rb.gravityScale = 0; // Turn off gravity
                rb.velocity = Vector2.zero; // Stop movement
                rb.isKinematic = true; // Ignore physics interactions
            }

            // Disable collisions while dragging
            if (col != null)
                col.enabled = false;
        }
    }

    void DragObject(Vector3 inputPosition)
    {
        transform.position = inputPosition + offset; // Move object while maintaining initial offset
    }

    void StopDrag()
    {
        isDragging = false;
        transform.localScale = Vector3.one * originalScale; // Reset scale back to original size
        transform.rotation = Quaternion.identity; // Reset rotation to original state

        // Re-enable physics + gravity
        if (rb != null)
        {
            rb.isKinematic = false; // Enable physics interactions again
            rb.gravityScale = 1; // Restore gravity
        }

        // Re-enable collisions
        if (col != null)
            col.enabled = true;
    }

    void AnimateDragging()
    {
        transform.localScale = Vector3.one * (originalScale * 1.1f); // Increase size while dragging
        timeElapsed += Time.deltaTime * rotationSpeed; // Increment time for oscillation
        float angle = Mathf.Sin(timeElapsed) * rotationAngle; // Calculate oscillating angle
        transform.rotation = Quaternion.Euler(0, 0, angle); // Apply rotation
    }
}
