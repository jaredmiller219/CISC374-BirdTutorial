using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
