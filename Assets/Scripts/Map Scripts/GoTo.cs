using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadOnTouchOrMouse : MonoBehaviour
{
    [SerializeField]
    private string Scene = "slay";
    void OnMouseDown()
    {
        Scene = gameObject.transform.name;
        SceneManager.LoadScene(Scene);
    }

}