using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMushroom : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * speed);
    }
}
