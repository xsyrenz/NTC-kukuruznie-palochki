using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechnizm : MonoBehaviour
{
    private Transform tf;
    private SpriteRenderer sprite;
    public LayerMask door;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        sprite = GetComponentInChildren<SpriteRenderer>();  
    }
    public void Action()
    {
        sprite.flipX = true;
        Collider2D[] mecs = Physics2D.OverlapCircleAll(tf.position, 100000000, door);
        foreach (Collider2D Door in mecs)
        {
            Door.GetComponent<Door>().Open();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
