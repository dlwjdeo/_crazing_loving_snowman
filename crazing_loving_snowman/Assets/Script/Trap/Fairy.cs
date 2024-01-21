using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public int x;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            playerController call = GameObject.Find("Player").GetComponent<playerController>();
            call.hp = x;
        }
    }
}
