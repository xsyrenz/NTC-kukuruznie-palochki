using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspAI : MonoBehaviour
{
    public float speedx = -7;
    public float speedy = -7;
    public float koefx = -1f;
    public float koefy = -1f;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity= new Vector2(speedx, speedy);
        sp= GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        speedx *= koefx;
        speedy *= koefy;
        if (speedx > 0)
        {
            sp.flipX= true;
        }
        else
        {
            sp.flipX= false;
        }
        rb.velocity = new Vector2(speedx, speedy);
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
