using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class snowduckcontroller : MonoBehaviour
{
    private Animator sdAnimation;
    private CircleCollider2D sdCollider;
    private SpriteRenderer sdRender;
    private float timer;
    private float collitimer;
    private bool coldown;

    // Start is called before the first frame update
    void Start()
    {
        sdAnimation = GetComponent<Animator>();
        sdCollider = GetComponent<CircleCollider2D>();
        sdRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coldown)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 6.5f)
        {
            sdCollider.enabled = true;
            coldown = false;
            timer = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sdAnimation.SetBool("colli", true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collitimer += Time.deltaTime;


            if (collitimer < 1.5)
            {
                sdAnimation.SetBool("close", true);
            }
            else
            {
                sdAnimation.SetBool("close", false);
            }
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sdAnimation.SetBool("colli", false);
            coldown = true;
            collitimer = 0;
            sdCollider.enabled = false;
        }
    }

}
