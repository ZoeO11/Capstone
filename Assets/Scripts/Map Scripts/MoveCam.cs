using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public bool ifMove;
    public Vector3 dir = new Vector3(0, 0, 0);
    public int speed = 5;
    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetMouseButton(0)) // 0 is the left mouse button
        {
        }
        else
        {
            ifMove = false;
        }
        if (ifMove == true)
        {
            transform.Translate(dir * Time.deltaTime * speed);
        }


    }
    public void MoveCameraRight()
    {
        ifMove = true;
        dir = Vector3.right;
    }
    public void MoveCameraLeft()
    {
        ifMove = true;
        dir = Vector3.left;
    }

}
