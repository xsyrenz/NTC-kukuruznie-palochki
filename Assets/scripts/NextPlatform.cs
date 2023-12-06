using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform nextPlatform;
    public Transform prevPlatform;
    void Start()    
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextPlatform.gameObject.SetActive(true);
            prevPlatform.gameObject.SetActive(false);
        }
    }
}
