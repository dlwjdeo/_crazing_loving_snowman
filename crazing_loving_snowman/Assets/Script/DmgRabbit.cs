using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgRabbit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerController call = GameObject.Find("Player").GetComponent<playerController>();
        if (other.tag == "Player")
        {
            call.hp = call.hp - 20;
        }
    }
}
