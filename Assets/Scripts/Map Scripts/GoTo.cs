using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadOnTouchOrMouse : MonoBehaviour
{
    [SerializeField]
    private string Scene;
    void OnMouseDown()
    {
        StartCoroutine(PlayAudioWithDelay());

    }
    IEnumerator PlayAudioWithDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(Scene);
    }
}