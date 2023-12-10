using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LensRotate : MonoBehaviour
{
    public Transform ray;

    public bool playerNearby = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && playerNearby)
        {
            gameObject.GetComponent<Transform>().Rotate(0, 0, 1);
        }
        float a = gameObject.transform.rotation.z;
        if (a < 0)
        {
            a = -a;
        }
        ray.GetComponent<SpriteRenderer>().color = new Color(0.9f, 0.9f, 0.32f, 1f - a * 2);
        if (1f - a > 0.9f)
        {
            ray.GetComponent<Fire>().isFire = true;
        }
        else
        {
            ray.GetComponent<Fire>().isFire = false;
        }
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
