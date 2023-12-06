using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspAI : MonoBehaviour
{
    public int speed = -7; 
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity= new Vector2(speed, 0);
        sp= GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed *= -1;
        if (speed > 0)
        {
            sp.flipX= true;
        }
        else
        {
            sp.flipX= false;
        }
        rb.velocity = new Vector2(speed, 0);
        if (collision.CompareTag("Player"))
        {
            Heartsystem.health -= 1;
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
