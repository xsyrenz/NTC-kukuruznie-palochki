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

        ray.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 90 - gameObject.GetComponent<Transform>().rotation.z);
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
