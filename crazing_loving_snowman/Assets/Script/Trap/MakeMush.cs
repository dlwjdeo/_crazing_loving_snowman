using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMush : Trap
{
    [SerializeField] private GameObject mushroom;
    [SerializeField] private Sprite stool;


    //private void Start()
    //{

    //    Invoke("instantMushroom", 2f);
    //}

    //private void instantMushroom()
    //{
    //    Vector3 vec = gameObject.transform.position;
    //    Instantiate(mushroom, vec, Quaternion.identity);
    //}

    public override void Effect()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = stool;
        
        StartCoroutine("instantMushroom");
    }

    IEnumerator instantMushroom()
    {
        yield return new WaitForSeconds(2.0f);

        Instantiate(mushroom, gameObject.transform.position, Quaternion.identity);
    }

   
}
