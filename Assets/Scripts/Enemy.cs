using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Speed;

    public float MoveX ;

    Rigidbody2D rb;

    SpriteRenderer sp;

    CapsuleCollider2D capsule2d;

    LayerMask Ground;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        capsule2d = GetComponent<CapsuleCollider2D>();
        Ground = LayerMask.GetMask("Ground");
        MoveX = transform.localScale.x;
    }

    void Update()
    {
        //El sprite da la vuelta según la variable
        transform.localScale = new Vector2(MoveX, transform.localScale.y);
        // 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(MoveX, 0), capsule2d.size.x / 2 + 0.5f, Ground.value);
        // Movimiento
        rb.velocity = new Vector2(MoveX, 0) * Speed;

        if(hit.collider != null)
        {
            print("kk");
            MoveX *= -1;
        }
    }
}
