using N.Fridman.CameraFollow.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS : MonoBehaviour
{
    private Transform tf;
    public int move = 1;
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move == 2)
        {
            if (tf.position.x > -27)
            {
                tf.Translate(-speed, 0f, 0);
            }
            if (tf.position.y > 2)
            {
                tf.Translate(0f, -speed, 0);
            }
            if (tf.position.y <= 2 && tf.position.x <= -27)
            {
                move = 3;
            }
        }
        if (move == 3)
        {
            if (tf.position.x < -13)
            {
                tf.Translate(speed, 0f, 0);
            }
            if (tf.position.y < 10)
            {
                tf.Translate(0f, speed, 0);
            }
            if (tf.position.y >= 10 && tf.position.x >= -13)
            {
                move = 4;
                CameraFollow2D.cse = 1;
            }
        }
        if (move == 1)
        {
            if (tf.position.x < 15)
            {
                tf.Translate(speed, 0f, 0);
            }
            if (tf.position.y < 6)
            {
                tf.Translate(0f, speed, 0);
            }
            if (tf.position.y >= 6 && tf.position.x >= 15)
            {
                move = 2;
                
            }
        }
    }
}
