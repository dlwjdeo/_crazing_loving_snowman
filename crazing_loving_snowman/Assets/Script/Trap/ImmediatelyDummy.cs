using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmediatelyDummy : MonoBehaviour
{
    private float destroyTimeI = 0.1f;
    void destroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Invoke("destroy", destroyTimeI * 1f);
        }
    }
}
