using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shoot : MonoBehaviour
{

    public float timer=5f;
    public float t;
    public Transform bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (t < timer)
        {
            t += Time.deltaTime;
        }
        else
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            t = 0f;
        }
    }
}
