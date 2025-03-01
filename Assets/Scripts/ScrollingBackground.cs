using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    // The speed of the scrolling
    public float scrollSpeed;

    // The reference to the GameStateManager script
    public GameStateManager gameState;

    // The renderer of the background
    [SerializeField]
    private Renderer backgroundRenderer;

    void Update()
    {
        if (!gameState.isGameOver){
            backgroundRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
        }

        else {
            Destroy(gameObject);
        }
    }
}
