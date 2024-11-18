using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadOnTouchOrMouse : MonoBehaviour
{
    [SerializeField]
    private string Scene = "slay";
    void OnMouseDown()
    {
        SceneManager.LoadScene(Scene);
    }

}