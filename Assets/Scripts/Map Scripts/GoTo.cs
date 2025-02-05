using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadOnTouchOrMouse : MonoBehaviour
{
    [SerializeField]
    private string Scene;
    void OnMouseDown()
    {
        SceneManager.LoadScene(Scene);
    }

}