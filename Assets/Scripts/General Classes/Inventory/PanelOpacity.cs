using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelOpacity : MonoBehaviour
{
    public TextMeshProUGUI textToFollow;

    private Image panelImage;

    void Awake()
    {
        panelImage = GetComponent<Image>();
    }

    void Update()
    {
        if (textToFollow != null)
        {
            float textAlpha = textToFollow.color.a;

            // Scale to max 0.5 opacity
            float panelAlpha = textAlpha * 0.5f;

            Color panelColor = panelImage.color;
            panelColor.a = panelAlpha;
            panelImage.color = panelColor;
        }
    }
}



