using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


public void StartGame()
{
    Time.timeScale = 1;
    SceneManager.LoadScene("Game");
}

public void QuitGame()
{
    Application.Quit();
}
}
