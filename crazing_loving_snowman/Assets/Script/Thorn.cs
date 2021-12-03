using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController call = GameObject.Find("Player").GetComponent<playerController>();
        call.hp = call.hp - 100;
    }
}
