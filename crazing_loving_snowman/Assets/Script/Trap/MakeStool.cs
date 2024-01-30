using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//»ç¿ëx
public class MakeStool : MonoBehaviour
{
    public GameObject stool;

    private void pushStool()
    {
        Vector3 vec = gameObject.transform.position;
        Instantiate(stool, vec, Quaternion.identity);
        Destroy(gameObject);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {

            pushStool();

        }
    }
}
