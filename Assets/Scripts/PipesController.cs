using UnityEngine;

public class PipesController : MonoBehaviour
{

    // This is the speed at which the pipe will move
    // public float moveSpeed = 5;

    // This is the position where the pipe will be destroyed
    public float deadSpace = -40f;

    // This is a reference to the GameStateManager script
    private GameStateManager gameState;

    // The base speed of the pipe
    public float baseSpeed = 5f;

    // The maximum speed of the pipe
    public float maxSpeed = 10f;

    // The current speed of the pipe
    public float currentSpeed;

    // The speed multiplier
    public float speedMultiplier = 5f;

    // The last score checked for speed increase
    private int lastCheckedScore = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
        currentSpeed = baseSpeed;
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
             // Increase speed when score is a multiple of 3 and hasn't been counted yet
            if (gameState.pointsScored >= 3 && gameState.pointsScored % 3 == 0 && gameState.pointsScored != lastCheckedScore)
            {
                currentSpeed *= speedMultiplier; // Increase speed by 10%
                currentSpeed = Mathf.Clamp(currentSpeed, baseSpeed, maxSpeed); // Ensure it doesn't exceed maxSpeed
                lastCheckedScore = gameState.pointsScored; // Store last updated score to prevent repeated increases at the same value
            }

            transform.position += Vector3.left * currentSpeed * Time.deltaTime;
        }

        if (gameObject.transform.position.x < deadSpace)
        {
            Destroy(gameObject);
        }
    }

}
