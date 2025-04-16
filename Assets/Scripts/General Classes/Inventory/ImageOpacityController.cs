using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageOpacityController : MonoBehaviour
{
    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();
        UpdateOpacity();
    }

    void Update()
    {
        // Optional: Check each frame if the sprite changes
        UpdateOpacity();
    }

    private void UpdateOpacity()
    {
        if (img.sprite == null)
        {
            Color color = img.color;
            color.a = 0f;
            img.color = color;
        }
        else
        {
            Color color = img.color;
            color.a = 1f;
            img.color = color;
        }
    }
}