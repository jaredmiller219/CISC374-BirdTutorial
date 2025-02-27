using UnityEngine;

public class PipesController : MonoBehaviour
{

    // This is the speed at which the pipe will move
    public float moveSpeed = 5;

    // This is the position where the pipe will be destroyed
    public float deadSpace = -40; // Changed from int to float and adjusted value

    // This is a reference to the GameStateManager script
    private GameStateManager gameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.isGameOver)
        {
            Destroy(gameObject);
            return;
        }

        if (!gameState.isGameOver)
        {
            transform.position = transform.position + ((Vector3.left * moveSpeed) * Time.deltaTime);
        }

        if (gameObject.transform.position.x < deadSpace)
        {
            Destroy(gameObject);
        }
    }
}
