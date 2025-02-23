using UnityEngine;

public class PipesController : MonoBehaviour
{
    public float moveSpeed = 0.2f;

    public int deadSpace = -40;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // gameObject.transform.position = transform.position + Vector3.left * 0.2f;
        gameObject.transform.position = transform.position + ((Vector3.left * moveSpeed) * Time.deltaTime);
        if (gameObject.transform.position.x < deadSpace)
        {
            Destroy(gameObject);
        }
    }
}
