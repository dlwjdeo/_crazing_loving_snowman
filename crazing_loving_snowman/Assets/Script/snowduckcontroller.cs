using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class snowduckcontroller : MonoBehaviour
{
    private Animator sdAnimation;
    private CircleCollider2D sdCollider;
    private SpriteRenderer sdRender;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        sdAnimation = GetComponent<Animator>();
        sdCollider = GetComponent<CircleCollider2D>();
        sdRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
            sdAnimation.SetTrigger("coliision");
            if (timer <= 6.5f)
            {
                if (timer >= 1.5f)
                {
                    sdCollider.enabled = false;
                    sdRender.color = new Color(1, 1, 1, 0);
                }
            }
            else
            {
                sdCollider.enabled = true;
                sdRender.color = new Color(1, 1, 1, 1);
                timer = 0;
            }
            
        }
        
    }
}
