using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoop : MonoBehaviour
{
    public bool rotate;
    public float tmp;
    public float rotateSpeed;
    private Vector3 position;
    private EdgeCollider2D col;
    private Rigidbody2D rigid;
    private void Start()
    {
        position = gameObject.transform.position;
        col = GetComponent<EdgeCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        
    }
    private void Update()
    {
        gameObject.transform.position = position;
        if(rotate == true)
        {
            tmp += rotateSpeed * Time.deltaTime;
            if(tmp < 90)
            {
                transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            }
            else
            {
                rotate = false;
            }

            if(tmp>60)
            {
                col.isTrigger = true;
            }
        }
    }
}
