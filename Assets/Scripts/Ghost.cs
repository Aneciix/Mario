using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    private Rigidbody2D rb;

    public float JForce;

    public float moveX;

    public float moveY;

    public float Speed;

    public bool touchingdown;

    private Animator animator;

    public bool Lookright;

    private SpriteRenderer sp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();


        float ScreenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
    }


    void Update()
    {
        Movement();
        Respawn();

        RaycastHit2D kk = Physics2D.Raycast(transform.position, Vector2.down);   // Genera Raycast hacia abajo

        if(kk.distance < 1.1)     // Dectecta si toca el suelo para saltar solo si lo toca
        {
            touchingdown = true;
        }
        else
        {
            touchingdown = false;
        }

        void Movement()
        {
            // Para moverse de un lado a otro
            moveX = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(moveX * Speed, rb.velocity.y);

            //Para saltar
            if (Input.GetKeyDown(KeyCode.Space)&&touchingdown)
            {
                Jump();
            }

            // Animación

            if (Mathf.Abs(moveX) > 0.1f) { animator.SetBool("isWalking", true); }
            else { animator.SetBool("isWalking", false); }
            
            //Animación de salto
            if (Input.GetKey(KeyCode.Space)||!touchingdown)
            {
                animator.SetBool("isJumping", true);
            }
            else { animator.SetBool("isJumping", false);
            }

            //Direccion a la que mira el jugador
            if (moveX > 0)
            {
                sp.flipX = false;
            }
            else if (moveX < 0)
            {
                sp.flipX = true;
            }
        }

        void Jump() // Se añade una fuerza para poder saltar
        {
            rb.AddForce(Vector2.up * JForce);
        }

        // El Respawn
        void Respawn()
        {
            if (transform.position.y < -5.71f) 
            {
                SceneManager.LoadScene("SampleScene");
            }

        }
    }

    //Detecta las colisiones
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    //Detecta los triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Para que muera"))
        {
            Destroy(collision.transform.parent.gameObject);
            rb.velocity = new Vector2(rb.velocity.x, JForce/80);
        }
    }

}
