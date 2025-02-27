using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public int pointsScored;

    public Text scoreText;

    public GameObject gameOverScreen;

    public bool isGameOver = false;

    public AudioClip deathSound;

    public AudioClip scoreSound;

    private AudioSource audioSource;

    void Start()
    {
        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            LoadMenu();
        }
    }

    [ContextMenu("Increase Score")]

    public void AddScore(int scoreToAdd)
    {
        pointsScored = pointsScored + scoreToAdd;
        scoreText.text = pointsScored.ToString();
        audioSource.PlayOneShot(scoreSound, 0.4f);
        checkHighScore();
    }

    public void checkHighScore()
    {
        if (pointsScored > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", pointsScored);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pointsScored = 0;
        scoreText.text = pointsScored.ToString();
        isGameOver = false;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound, 0.4f);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
