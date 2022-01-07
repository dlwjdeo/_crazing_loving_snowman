using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoop : MonoBehaviour
{
    public float JumpForce;
    public float xForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerController call = GameObject.Find("Player").GetComponent<playerController>();
        call.jumpPower = JumpForce;
        Invoke("jump", 1f);
    }


    private void jump()
    {
        playerController call = GameObject.Find("Player").GetComponent<playerController>();
        call.scoopJump = true;
    }
}
