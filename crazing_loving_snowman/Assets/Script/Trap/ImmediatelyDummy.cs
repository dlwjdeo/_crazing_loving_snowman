using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용x 더미통합
public class ImmediatelyDummy : Trap
{
    //private float destroyTimeI = 0.1f;
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
    override public void Effect(playerController Player)
    {
        StartCoroutine(Destroy());
    }
    override public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
