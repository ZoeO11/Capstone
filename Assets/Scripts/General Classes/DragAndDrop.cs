using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D
        col = GetComponent<Collider2D>();  // Get Collider2D
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Mouse click
            TryStartDrag(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButton(0) && isDragging) // Mouse drag
            DragObject(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonUp(0)) // Mouse release
            StopDrag();

        if (Input.touchCount > 0) // Touch input
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
                TryStartDrag(touchPos);

            if (touch.phase == TouchPhase.Moved && isDragging)
                DragObject(touchPos);

            if (touch.phase == TouchPhase.Ended)
                StopDrag();
        }
    }

    void TryStartDrag(Vector3 inputPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(inputPosition, Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            offset = transform.position - inputPosition;

            // Disable physics while dragging
            if (rb != null)
            {
                rb.gravityScale = 0; // Turn off gravity
                rb.velocity = Vector2.zero; // Stop movement
                rb.isKinematic = true; // Ignore physics
            }

            // Disable collisions while dragging
            if (col != null)
                col.enabled = false;
        }
    }

    void DragObject(Vector3 inputPosition)
    {
        transform.position = inputPosition + offset;
    }

    void StopDrag()
    {
        isDragging = false;

        // Re-enable physics + gravity
        if (rb != null)
        {
            rb.isKinematic = false; // Enable physics
            rb.gravityScale = 1; // Restore gravity
        }

        // Re-enable collisions
        if (col != null)
            col.enabled = true;
    }
}