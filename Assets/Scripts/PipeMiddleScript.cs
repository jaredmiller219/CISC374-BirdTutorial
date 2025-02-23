using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeMiddleScript : MonoBehaviour
{
    public GameStateManager logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.Find("Logic").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        logic.AddScore();
    }
}
