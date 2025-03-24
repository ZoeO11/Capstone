using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCam : MonoBehaviour
{
    public bool ifMove;
    public Vector3 dir = new Vector3(0, 0, 0);
    public int speed = 5;
    public Button rightButton;
    public Button leftButton;
    public GameObject inventoryColider;
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
            if(transform.position.x >= 14.39 && dir == Vector3.right)
            {
                
            }
            else if(transform.position.x <= 0 && dir == Vector3.left)
            {

            }
            else
            { transform.Translate(dir * Time.deltaTime * speed);
              inventoryColider.transform.Translate(dir * Time.deltaTime * speed);
            }
            
        }


    }
    public void MoveCameraRight()
    {
        if(transform.position.x >= 14.39)
        {
            rightButton.gameObject.SetActive(false);
        }
        leftButton.gameObject.SetActive(true);
        ifMove = true;
        dir = Vector3.right;
    }
    public void MoveCameraLeft()
    {
        if (transform.position.x <= 0)
        {
            leftButton.gameObject.SetActive(false);
        }
        rightButton.gameObject.SetActive(true);
        ifMove = true;
        dir = Vector3.left;
    }

}
