using UnityEngine;


public class CharController : MonoBehaviour
{
    // This is a reference to the player GameObject
    public GameObject player;

    // This is the jump force that will be applied to the player
    public float jumpForce = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            jump();
        }
    }

    void jump(){
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
    }
}
