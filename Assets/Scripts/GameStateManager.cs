using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public int pointsScored;

    public Text scoreText;

    public GameObject gameOverScreen;

    public bool isGameOver = false;

    public AudioClip deathSound;

    public AudioClip scoreSound;

    private AudioSource audioSource;

    private AudioSource bgMusicSource;

    public AudioClip gameMusic;

    public TextMeshProUGUI highScoreText;

    void Start()
    {
        updateHighScoreText();
        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            bgMusicSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
            bgMusicSource = GetComponent<AudioSource>();
        }

        bgMusicSource.clip = gameMusic;
        bgMusicSource.loop = true;
        bgMusicSource.Play();
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

    public void updateHighScoreText()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
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
        bgMusicSource.Stop();
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
