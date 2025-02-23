using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public int pointsScored;

    public Text scoreText;

    [ContextMenu("Increase Score")]

    public void AddScore(int scoreToAdd)
    {
        pointsScored = pointsScored + scoreToAdd;
        Debug.Log("Points scored: " + pointsScored);
        scoreText.text = pointsScored.ToString();
    }
}
