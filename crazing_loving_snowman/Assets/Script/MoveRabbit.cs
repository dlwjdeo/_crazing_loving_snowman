using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRabbit : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public int h;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(-1, rigid.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("jumpRabbit", 2f);
    }
    void jumpRabbit()
    {
        rigid.AddForce(Vector2.up * h, ForceMode2D.Impulse);
    }
    void turnDirection()
    {

    }
}
