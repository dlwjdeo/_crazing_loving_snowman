using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//»ç¿ë x
public class Thorn : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerController call = GameObject.Find("Player").GetComponent<playerController>();
            //call.hp = call.hp - 100;
        }
    }
}
