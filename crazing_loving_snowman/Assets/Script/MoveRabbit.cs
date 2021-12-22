using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRabbit : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public int h;
    public float rabbitSpeed;
    public float speed;
    public int rabbitJumpCount;
    private int jumpCount = 0;
    private int turn = 1;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(rabbitSpeed, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rabbitSpeed = 0;
        Invoke("jumpRabbit", 2f);
        turnDirection();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rabbitSpeed = -speed * turn;
        jumpCount++;
    }
    void jumpRabbit()
    {
        rigid.AddForce(Vector2.up * h, ForceMode2D.Impulse);
    }
    void turnDirection()
    {
        if (jumpCount >= rabbitJumpCount)
        {
            turn = turn * (-1);
            jumpCount = 0;
        }
    }
}
