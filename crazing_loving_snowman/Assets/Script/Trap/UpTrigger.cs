using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrigger : MonoBehaviour
{
    public bool up;
    private Rigidbody2D rigid;
    public Transform target;
    public float x;
    public float y;
    public float moveSpeed;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        up = false;
    }

    private void Update()
    {
        if(up == true)
        {
            if(gameObject.transform.position.y < y)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(x, y, 0);
                up = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("upTrigger",2f);
        }
    }

    void upTrigger()
    {
        up = true;
    }
}
