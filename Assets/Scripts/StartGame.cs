using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}