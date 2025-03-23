using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script2 : MonoBehaviour
{
    public GameObject closedDoor;
    // Start is called before the first frame update

    // Update is called once per frame
    void OnMouseDown()
    {
        gameObject.SetActive(false);
        closedDoor.SetActive(true);
    }
}
