using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMush : MonoBehaviour
{
    public GameObject mushroom;

    private void Start()
    {

        Invoke("instantMushroom", 2f);
    }

    private void instantMushroom()
    {
        Vector3 vec = gameObject.transform.position;
        Instantiate(mushroom, vec, Quaternion.identity);
    }
}
