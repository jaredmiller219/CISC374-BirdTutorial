using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    // The prefab of the pipes spawner
    public GameObject PipesSpawner;

    // The timer to keep track of the time between each spawn
    private float timer = 0.0f;

    // The time between each spawn
    private float spawnTime = 4.0f;

    public float baseSpawnTime = 4.0f; // Initial spawn interval

    // The highest offset from the center of the screen
    public float highestOffset = 10;

    private float baseSpeed = 5f; // Match the base speed from PipesController

    private float currentSpeed; // Syncs with PipesController

    private PipesController pipeController;

    private GameStateManager gameState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(PipesSpawner, transform.position, transform.rotation);
        gameState = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
        spawnTime = baseSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameState.isGameOver)
        {
            AdjustSpawnRate();
            if (timer < spawnTime)
            {
                timer += Time.deltaTime;
            }
            else {
                spawnPipes();
                timer = 0.0f;
            }
        }
    }

    void spawnPipes()
    {
        float lowestPoint = transform.position.y - highestOffset;
        float highestPoint = transform.position.y + highestOffset;

        Instantiate(PipesSpawner, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }


    void AdjustSpawnRate()
    {
        // Get the current speed from the PipesController
        if (PipesSpawner != null)
        {
            pipeController = PipesSpawner.GetComponent<PipesController>();
            if (pipeController != null)
            {
                currentSpeed = pipeController.currentSpeed;
                spawnTime = baseSpawnTime * (currentSpeed / baseSpeed);
            }
        }
    }
}
