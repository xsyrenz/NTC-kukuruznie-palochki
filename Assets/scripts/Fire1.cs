using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class Fire1 : MonoBehaviour
{
    public bool isFire = false;
    public float timer = 5f;
    public float t = 0f;
    public int i = 1;

    private SpriteRenderer sp;

    private void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isFire == true)
        {
            if (t > timer)
            {
                if (i == 1)
                {
                    i = 0;
                }
            }
            else
            {
                t += Time.deltaTime;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Flammable") && isFire == true && collision.GetComponent<Fire>().isFire == false && t > timer)
        {
            collision.GetComponent<Fire>().isFire = true;
        }
    }


}
