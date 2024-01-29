using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//»ç¿ë x
public class ImageChange : MonoBehaviour
{
    public GameObject after;

    private Transform afterTransform;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("changeObject", 1f);
        }
    }

    private void changeObject()
    {
        Vector3 vec = gameObject.transform.position;
        Instantiate(after, vec, Quaternion.identity);       
        Destroy(gameObject);
    }
}
