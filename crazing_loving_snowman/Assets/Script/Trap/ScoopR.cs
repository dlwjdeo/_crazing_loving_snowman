using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopR : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public bool rotate;
    private float count;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 0f;
        rotate = false;
        count = 0;
    }

    void FixedUpdate()
    {
        if (rotate == true)
        {
            if (rigidBody2D.rotation > -70f)
            {
                rigidBody2D.rotation -= 10.0f;
            }
            else
            {
                playerController call = GameObject.Find("Player").GetComponent<playerController>();
                call.Rscoop = true;
                rigidBody2D.rotation = -70f;
                rotate = false;
                Invoke("resetScoop", 2f);
            }
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (count >= 0)
            {
                count--;
                Invoke("rotateScoop", 2f);
            }
        }
    }
    void rotateScoop()
    {
        rotate = true;
    }
    void resetScoop()
    {
        rigidBody2D.rotation = 0f;
        count++;
    }
}
