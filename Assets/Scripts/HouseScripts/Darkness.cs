using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    public SpriteRenderer darkness;
    // Start is called before the first frame update
    void Start()
    {
        darkness.enabled = false;
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("window click");
        if (darkness.enabled)
        {
            Debug.Log("true");
            darkness.enabled = false;
        }
        else
        {
            Debug.Log("False");
            darkness.enabled = true;
        }
    }
}
