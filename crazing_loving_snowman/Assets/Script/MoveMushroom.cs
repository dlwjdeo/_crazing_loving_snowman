using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMushroom : MonoBehaviour
{
    Rigidbody2D rigid;
    public Transform target;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    private Vector2 bottomVec;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            Destroy(gameObject);
        }
    }
}
