using UnityEngine;


public class CharController : MonoBehaviour
{
    // This is a reference to the player GameObject
    public GameObject player;

    // This is the jump force that will be applied to the player
    public float jumpForce = 10;

    // This is a reference to the GameStateManager script
    public GameStateManager logic;

    public bool isAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive == true)
        {
            jump();
        }
    }

    void jump(){
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }
}
