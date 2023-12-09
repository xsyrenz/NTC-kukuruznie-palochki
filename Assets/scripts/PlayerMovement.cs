using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 15f;

    private Rigidbody2D rb;

    public LayerMask Ground;
    public LayerMask Honey;

    public bool onGround;
    public bool isSlowed;

    [Range(-10f, 5f)] public float CheckGroundOffsetY = 0f;
    [Range(0, 5f)] public float CheckGroundRadius = 0.1f;

    [Range(-10f, 5f)] private float isSlowedOffsetY = 0f;
    [Range(0, 5f)] private float isSlowedRadius = 0.1f;

    public bool djump = false;
    public float djumpout = 0f;
    public bool dj = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        djumpOut();

        onGround = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + CheckGroundOffsetY), CheckGroundRadius, Ground);
        isSlowed = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + isSlowedOffsetY), isSlowedRadius, Honey);
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)) // Проверка, может ли персонаж прыгать.
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Задание скорости движения по y.
                if (djump == true)
                {
                    dj = true;
                }
            }
            else if (dj)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Задание скорости движения по y.
                dj = false;
            }
        }

        if (isSlowed)
        {
            speed = 0.5f;
            jumpForce = 3;
        }
        else
        {
            speed = 10f;
            jumpForce = 15f;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Comb"))
        {
            djump = true;
            djumpout = 0f;
        }
    }

    void djumpOut()
    {
        if (djump)
        {
            if (djumpout < 5f)
            {
                djumpout += Time.deltaTime;
            }
            else
            {
                djump = false;
                djumpout = 0f;
            }
        }
    }
}
