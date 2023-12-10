using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspAIround : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedx = -7;
    public float speedy = 7;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    public int n = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speedx, 0);
        sp = GetComponent<SpriteRenderer>();
         
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("Player"))
        {
            Heartsystem.health -= 1;
        }
        if (n == 1)
        {
            rb.velocity = new Vector2(speedx, 0.01f);
            n = 2;
        }
        else if(n == 2)
        {
            rb.velocity = new Vector2(0.1f, speedy);
            n = 3;
        }
        else if (n == 3)
        {
            rb.velocity = new Vector2(speedx * -1, -0.01f);
            n = 4;
        }
        else if (n == 4)
        {
            rb.velocity = new Vector2(-0.01f, speedy * -1);
            n = 1;
        }
        /*if (rb.velocity == Vector2.zero)
        {
            rb.velocity = new Vector2(speedx, 0);
        }
        if (rb.velocity == Vector2.zero)
        {
            rb.velocity = new Vector2(0.1f, speedy * -1);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocityX > 0)
        {
            sp.flipX = true;
        }
        else
        {
            sp.flipX = false;
        }
    }
}
