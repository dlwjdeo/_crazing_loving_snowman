using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//���x
public class ScoopRotate : MonoBehaviour
{
    //private Rigidbody2D rigid2D;

    private void Awake()
    {
       // rigid2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("rotateTrue", 2f);
        }
    }

    private void rotateTrue()
    {
        Scoop call = GameObject.Find("����M").GetComponent<Scoop>();
        call.rotate = true;
    }
}
