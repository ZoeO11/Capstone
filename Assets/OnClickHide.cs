using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickHide : MonoBehaviour
{
    public GameObject phoneAnimation;
    public GameObject phoneBack;


    void OnMouseDown()
    {
        phoneAnimation.SetActive(false);
        phoneBack.SetActive(false);
    }
}
