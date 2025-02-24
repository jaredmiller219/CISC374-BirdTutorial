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

    [ContextMenu("Increase Score")]

    public void AddScore(int scoreToAdd)
    {
        pointsScored = pointsScored + scoreToAdd;
        Debug.Log("Points scored: " + pointsScored);
        scoreText.text = pointsScored.ToString();
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
}
