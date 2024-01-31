using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMushroom : Trap
{
    Rigidbody2D rigid;
    public Transform target;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    private Vector2 bottomVec;

    override public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigid = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        bottomVec = new Vector2(rigid.position.x, rigid.position.y - 3);
        Debug.DrawRay(bottomVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(bottomVec, Vector3.down, 1);
        if (rayHit.collider != null)
        {

        }
    }

    //override public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Player")
    //    {
            
    //        StartCoroutine(StopMove());
    //        Destroy(gameObject);
    //    }
    //}
    public override void Effect()
    {
        StartCoroutine(StopMove());
    }
    private IEnumerator StopMove()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(5.0f);
        Player.playerMove(false);


    }
}
