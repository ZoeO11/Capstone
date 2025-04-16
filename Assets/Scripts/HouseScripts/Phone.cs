using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject phoneAnimation;
    public GameObject phoneBack;


    void Start()
    {

        if (phoneAnimation != null)
        {
            phoneAnimation.SetActive(false);  // Ensure phone animation is initially hidden
            phoneBack.SetActive(false);  // Hide phone back initially
        }
    }

    void OnMouseDown()
    {
        ActivatePhone();

    }

    void ActivatePhone()
    {
        if (phoneAnimation != null)
        {
            phoneAnimation.SetActive(true);  // Show phone animation
            phoneBack.SetActive(true);  // Show phone back
        }
    }
}
