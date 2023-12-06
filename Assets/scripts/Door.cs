using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform tf;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    public void Open()
    {
        Debug.Log("Open");
        rb.velocity = new Vector2(0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
