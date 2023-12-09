using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform tf;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private Collider2D cl;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        cl = GetComponent<Collider2D>();
    }
    public void Open()
    {
        Debug.Log("Open");
        sprite.color= Color.grey;
        cl.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
