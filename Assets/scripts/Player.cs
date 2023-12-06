using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Player : MonoBehaviour
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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + CheckGroundOffsetY), CheckGroundRadius, Ground);
        isSlowed = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + isSlowedOffsetY), isSlowedRadius, Honey);
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);
       
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isSlowed)
        {
            speed = 0.5f;
            jumpForce= 3;
            Heartsystem.health += 1;
        }
        else
        {
            speed = 3f;
            jumpForce = 5f;
        }
    }
}
