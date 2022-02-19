using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpTrigger : MonoBehaviour
{
    private bool up;
    public Transform target;

    private void Start()
    {
        up = false;
    }

    private void Update()
    {
        if(up == true)
        {

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
