using System.Runtime.InteropServices;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    // The prefab of the pipes spawner
    public GameObject PipesSpawner;

    // The timer to keep track of the time between each spawn
    private float timer = 0.0f;

    // The time between each spawn
    public float spawnTime = 6.0f;

    // The highest offset from the center of the screen
    public float highestOffset = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(PipesSpawner, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else {
            spawnPipes();
            timer = 0.0f;
        }
    }

    void spawnPipes()
    {
        float lowestPoint = transform.position.y - highestOffset;
        float highestPoint = transform.position.y + highestOffset;

        Instantiate(PipesSpawner, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
