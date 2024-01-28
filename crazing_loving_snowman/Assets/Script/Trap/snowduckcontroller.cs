using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class snowduckcontroller : Trap
{
    private Animator sdAnimation;
    private CircleCollider2D sdCollider;
    //private SpriteRenderer sdRender;
    
    private float timer;
    [SerializeField] private float collitimer;
    private bool coldown;

    // Start is called before the first frame update
    override public void Start()
    {
        sdAnimation = GetComponent<Animator>();
        sdCollider = GetComponent<CircleCollider2D>();
        //sdRender = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    override public void Update()
    {
        if(coldown)
        {
            timer += Time.deltaTime;
        }

        if (timer >= 6.5f)
        {
            sdCollider.enabled = true;
            coldown = false;
            timer = 0;
        }
       
    }
    override public void OnTriggerEnter2D(Collider2D collision)
    {

        sdAnimation.SetBool("colli", true);

       
    }
     IEnumerator End(Collider2D collision)
    {
        yield return new WaitForSeconds(2.1f);

        collision.GetComponent<playerController>().tmpTime = 0;
        collision.GetComponent<playerController>().movement = true;
        collision.GetComponent<playerController>().playerRender.color = new Color(1, 1, 1, 1);
        collision.transform.position = new Vector2(transform.position.x, transform.position.y+3.0f);
        
       

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collitimer += Time.deltaTime;


            if (collitimer <= 1.5f)
            {
                sdAnimation.SetBool("close", true);

                collision.GetComponent<playerController>().movement = false;
                collision.GetComponent<playerController>().playerRigidbody.velocity = new Vector2(0, 0);
                collision.GetComponent<playerController>().playerRender.color = new Color(1, 1, 1, 0);
                collision.transform.position = transform.position;
                
            }
            else
            {
                sdAnimation.SetBool("close", false);

                
                StartCoroutine(End(collision));
            }

            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damage(collision.GetComponent<playerController>());
            sdAnimation.SetBool("colli", false);
            coldown = true;
            collitimer = 0;
            sdCollider.enabled = false;
            collision.GetComponent<playerController>().tmpTime = 0;
        }
    }

}
