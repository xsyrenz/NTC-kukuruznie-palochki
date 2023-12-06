using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;

public class Fire : MonoBehaviour
{
    public bool isFire = false;

    private SpriteRenderer sp;

    private void Start()
    {
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isFire == true)
        {
            sp.color = Color.red;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Flammable") && isFire == true && collision.GetComponent<Fire>().isFire == false)
        {
            collision.GetComponent<Fire>().isFire = true;
        }
    }


}
