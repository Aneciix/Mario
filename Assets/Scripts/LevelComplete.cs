using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject player;

    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }


    void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            rb.gravityScale = 4;
        }
    }
}
