using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame1()
    {
        if (!GameManager.instance.HasPlayedGame("game1"))
        {
            GameManager.instance.SetCurrentGame("game1");
            SceneManager.LoadScene("CharCreation");
        }
        else
        {
            GameManager.instance.SetCurrentGame("game1");
            SceneManager.LoadScene("Home");
        }
    }

    public void StartGame2()
    {
        if (!GameManager.instance.HasPlayedGame("game2"))
        {
            GameManager.instance.SetCurrentGame("game2");
            SceneManager.LoadScene("CharCreation");
        }
        else
        {
            GameManager.instance.SetCurrentGame("game2");
            SceneManager.LoadScene("Home");
        }
    }
}
