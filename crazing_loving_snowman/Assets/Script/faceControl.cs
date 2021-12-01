using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceControl : MonoBehaviour
{
    SpriteRenderer faceSpriterender;
    // Start is called before the first frame update
    void Start()
    {
        faceSpriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}

