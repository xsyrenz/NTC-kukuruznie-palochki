using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelStair : MonoBehaviour
{
    public Transform u1;
    public Transform u2;
    public Transform u3;


    // Update is called once per frame
    void Update()
    {
        if (u1.GetComponent<Collider2D>().isTrigger != true && u2.GetComponent<Fire>().isFire == true)
        {
            u3.gameObject.SetActive(false);
        }
    }
}
