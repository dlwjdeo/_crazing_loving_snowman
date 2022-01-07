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
        Wait();
        call.scoopJump = true;
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
