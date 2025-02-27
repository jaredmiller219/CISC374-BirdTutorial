using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public GameStateManager logic;

    private bool playerPassedSafely = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && !logic.isGameOver){
            playerPassedSafely = true;
            // logic.AddScore(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && playerPassedSafely && !logic.isGameOver)
        {
            logic.AddScore(1); // Only add the score when exiting safely
        }
    }
}
