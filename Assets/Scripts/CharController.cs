using UnityEngine;

public class CharController : MonoBehaviour
{
    public GameObject player;
    public float jumpForce = 10;
    public GameStateManager logic;
    public bool isAlive = true;
    public AudioClip jumpSound;
    public AudioSource audioSource;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameStateManager>();
        if (GetComponent<AudioSource>() == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.volume = 0.3f;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive == true)
        {
            jump();
        }

        if (transform.position.y > 17 || transform.position.y < -17)
        {
            logic.gameOver();
            isAlive = false;
        }
    }

    void jump(){
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * jumpForce;
        PlaySound(jumpSound, 0.3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }

    void PlaySound(AudioClip clip, float volumeScale = 0.5f)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip, volumeScale);
        }
    }
}
