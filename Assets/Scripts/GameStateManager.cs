using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    private int pointsScored = 0;

    public Text scoreText;

    [ContextMenu("Increase Score")]

    public void AddScore()
    {
        pointsScored++;
        // Debug.Log("Points scored: " + pointsScored);
        scoreText.text = pointsScored.ToString();
    }
}
