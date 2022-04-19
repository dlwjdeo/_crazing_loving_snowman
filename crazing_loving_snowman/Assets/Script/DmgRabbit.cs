using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgRabbit : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            playerController call = GameObject.Find("Player").GetComponent<playerController>();
            call.hp = call.hp - 20;
           
        }
    }
}
