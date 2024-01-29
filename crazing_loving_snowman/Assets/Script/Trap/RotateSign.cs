using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSign : Trap
{
    [SerializeField] private Sprite changeImage;
    //private int count = 1;
    //public int x, y;
    //private void Start()
    //{
    //    transform.Rotate(0, 0, x);
    //}
    //void rotate()
    //{
    //    if (count > 0)
    //    {
    //        transform.Rotate(0, 0, y);
    //        count--;
    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    Invoke("rotate", 1f);

    //}
    public override void Effect(playerController Player)
    {
        StartCoroutine("ChageImage");
    }
    IEnumerator ChageImage()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<SpriteRenderer>().sprite = changeImage;
    }
}

