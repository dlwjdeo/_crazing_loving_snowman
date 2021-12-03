using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public int x;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerController call = GameObject.Find("Player").GetComponent<playerController>();
        call.hp = x;
    }
}
