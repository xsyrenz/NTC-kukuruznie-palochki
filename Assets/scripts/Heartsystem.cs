using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartsystem : MonoBehaviour
{
    public static GameObject lastPos;
    public Transform player;

    [Range(0, 6)]public static int health = 6;
    public GameObject Heart1, Heart2, Heart3;
    void Start()
    {
        Heart1.SetActive(true);
        Heart2.SetActive(true);
        Heart3.SetActive(true);
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        switch(health)
        {
           
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);

                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);

                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                Destroy(player);
                Instantiate(player, lastPos.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                break;
        }   
        if (health > 3)
        {
            health = 3;
        }
    }
}
