using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrigger : Trap
{
    [SerializeField]private bool up;
    //private Rigidbody2D rigid;
    //public Transform target;
    //public float x;
    [SerializeField] private float y;
    [SerializeField] private float moveSpeed;

    //override public void Start()
    //{
    //    rigid = GetComponent<Rigidbody2D>();
    //    up = false;
    //}

    override public void Update()
    {
        if(up == true)
        {
            if(gameObject.transform.position.y < y)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, y, 0);
                up = false;
            }
        }
    }

    private IEnumerator upTrigger()
    {
        yield return new WaitForSeconds(2.0f);
        up = true;
    }

    override public void Effect()
    {
        StartCoroutine("upTrigger");
    }
}
