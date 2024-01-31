using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoop : Trap
{
    private Rigidbody2D rigidBody2D;
    public bool rotate;
    private float count;
    override public void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 0f;
        rotate = false;
        count = 0;
    }

    void FixedUpdate()
    {
        if (rotate == true && gameObject.CompareTag("L"))
        {
            if (rigidBody2D.rotation < 70f)
            {
                rigidBody2D.rotation += 10.0f;
            }
            else
            {
                //playerController call = GameObject.Find("Player").GetComponent<playerController>();
                //call.Lscoop = true;
                Player.Lscoop = true;
                rigidBody2D.rotation = 70f;
                rotate = false;
                //Invoke("resetScoop", 2f);
                StartCoroutine("resetScoop");
            }
        }
        else if (rotate == true && gameObject.CompareTag("R"))
        {
            if (rigidBody2D.rotation > -70f)
            {
                rigidBody2D.rotation -= 10.0f;
            }
            else
            {
                //playerController call = GameObject.Find("Player").GetComponent<playerController>();
                //call.Rscoop = true;
                Player.Lscoop = true;
                rigidBody2D.rotation = -70f;
                rotate = false;
                //Invoke("resetScoop", 2f);
                StartCoroutine("resetScoop");
            }
        }


    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        if(count >= 0 )
    //        {
    //            count--;
    //            //Invoke("rotateScoop", 2f);
    //            StartCoroutine("rotateScoop");
    //        }
    //    }
    //}
    public override void Effect()
    {
        //Player.GetComponent<Transform>().position
        if (count >= 0)
        {
            count--;
            //Invoke("rotateScoop", 2f);
            StartCoroutine("rotateScoop");
        }
    }
    //void rotateScoop()
    //{
    //    rotate = true;
    //}

    //void resetScoop()
    //{
    //    rigidBody2D.rotation = 0f;
    //    count++;
    //}
    IEnumerator rotateScoop()
    {
        yield return new WaitForSeconds(2.0f);
        rotate = true;
    }
    IEnumerator resetScoop()
    {
        yield return new WaitForSeconds(2.0f);
        rigidBody2D.rotation = 0f;
        count++;
    }
}
