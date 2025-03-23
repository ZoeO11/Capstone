using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript : MonoBehaviour
{
    public GameObject openDoor;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        openDoor.SetActive(false);
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        gameObject.SetActive(false);
        openDoor.SetActive(true);
    }
}
