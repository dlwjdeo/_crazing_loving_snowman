using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : Trap
{
    //private float destroyTimeI = 1.0f;
    //void destroy()
    //{
    //    Destroy(gameObject);
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        Invoke("destroy", destroyTimeI * 1f);
    //    }
    //}

    override public void Effect()
    {
        StartCoroutine(Destroy());
    }
    //override public void OnTriggerEnter2D(Collider2D collision)
    //{

    //}
}
