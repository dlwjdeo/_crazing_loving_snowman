using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Transform playerTrans;
    private SpriteRenderer playerRender;
    public GameObject FinishPanel;
    public GameObject UIPanel;
    public GameObject gameover;
    public Image FacePanelEye;
    public Image FacePanelNose;
    public Image FacePanelMouse;
    public bool gameOver;
    public float hp;
    private float pos;
    public bool Dmg;
    public float interval;
    public bool vis;
    private int Lvalue;
    private int Rvalue;
    private float maxSpeed;
    private bool eye;
    private bool nose;
    private bool mouse;
    private bool movement;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();
        playerRender = GetComponent<SpriteRenderer>();
        gameOver = false;
        hp = 1;
        pos = playerTrans.position.x;
        interval = 1;
        vis = true;
        Lvalue = 0;
        Rvalue = 0;
        maxSpeed = 10;
        eye = false;
        nose = false;
        mouse = false;
        movement = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            if (playerRigidbody.velocity.x <= maxSpeed)
            {
                float zInput = Input.GetAxisRaw("Horizontal") + Lvalue + Rvalue;
                playerRigidbody.AddForce(new Vector2(zInput, 0));
            }

        }

        if (Dmg == true)
        {
            invisible();
        }
        playerScale();

        if (hp <=0)
        {
            GameOver();
        }

        if (hp > 100)
        {
            hp = 100;
        }
               

    }

    public void ButtonDown(string type)
    {
        if (type == "L")
        {
            Lvalue = -1;
        }
        if (type == "R")
        {
            Rvalue = 1;
        }
    }

    public void ButtonUp(string type)
    {
        if (type == "L")
        {
            Lvalue = 0;
        }
        if (type == "R")
        {
            Rvalue = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (hp <= 100)
            {
                if (playerTrans.position.x - pos > 1)
                {
                    hp = hp + 1;
                    pos = playerTrans.position.x;
                }
                else if (playerTrans.position.x - pos < -1)
                {
                    hp = hp + 1;
                    pos = playerTrans.position.x;
                }

            }
                
        }        
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
        gameover.SetActive(true);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dmgTrap")
        {
            onDamage();
            Invoke("unDamage", 3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dmgTrap")
        {
            onDamage();
            Invoke("unDamage", 3);

            if (collision.gameObject.name == "wRabbit")
            {
                bounce(collision.transform.position);
            }
        }

        if (collision.gameObject.tag == "Finish")
        {
            UIPanel.SetActive(false);
            FinishPanel.SetActive(true);

        }

        if (collision.gameObject.name == "snowduck")
        {
            int tmpTime += Time.deltaTime;

            movement = false;
            playerRigidbody.velocity = new Vector2(0, 0);
            playerRender.color = new Color(1, 1, 1, 0);

            if (tmpTime >= 1.5f)
            {
                movement = true;
                playerRender.color = new Color(1, 1, 1, 1);
            }
        }

        if (collision.gameObject.name == "eRabbit")
        {
            int randomFace = Random.Range(1, 3);
            loseFace(randomFace);
        }

        if (collision.gameObject.tag == "Eye")
        {
            FacePanelEye.color = new Color(1, 1, 1, 1);
            eye = true;
        }

        if (collision.gameObject.tag == "Nose")
        {
            FacePanelNose.color = new Color(1, 1, 1, 1);
            nose = true;
        }

        if (collision.gameObject.tag == "Mouse")
        {
            FacePanelMouse.color = new Color(1, 1, 1, 1);
            mouse = true;
        }
    }
    private void playerScale()
    {
        if (hp < 24)
        {
            playerTrans.localScale = new Vector2(1, 1);
            playerRigidbody.mass = 1;
        }          
        else if (hp < 49)
        {
            playerTrans.localScale = new Vector2(1.2f, 1.2f);
            playerRigidbody.mass = 1.2f;
        }
        else if (hp < 74)
        {
            playerTrans.localScale = new Vector2(1.5f, 1.5f);
            playerRigidbody.mass = 1.5f;
        }
        else if (hp < 99)
        {
            playerTrans.localScale = new Vector2(1.8f, 1.8f);
            playerRigidbody.mass = 1.8f;
        }
        else if (hp >= 100)
        {
            playerTrans.localScale = new Vector2(2, 2);
            playerRigidbody.mass = 2;
        }
    }

    private void loseFace(int face)
    {
        if (face == 1)
        {
            if (eye)
            {
                FacePanelEye.color = new Color(1, 1, 1, 0.4f);
                eye = false;
            }
            else
            {
                loseFace(2);
            }

        }

        if (face == 2)
        {
            if (nose)
            {
                FacePanelNose.color = new Color(1, 1, 1, 0.4f);
                nose = false;
            }
            else
            {
                loseFace(3);
            }
        }

        if (face == 3)
        {
            if (mouse)
            {
                FacePanelMouse.color = new Color(1, 1, 1, 0.4f);
                mouse = false;
            }
            else
            {
                loseFace(1);
            }

        }
    }
    private void onDamage()
    {
        gameObject.layer = 7;
        Dmg = true;

    }

    private void bounce(Vector2 enemyPos)
    {
        int dirc = enemyPos.x - transform.position.x < 0 ? 1 : -1;
        playerRigidbody.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);
        
    }

    private void unDamage()
    {
        gameObject.layer = 6;
        Dmg = false;
        playerRender.color = new Color(1, 1, 1, 1);
        interval = 1;

    }

    private void invisible()
    {
        
        playerRender.color = new Color(1, 1, 1, interval);

        if(vis == true)
        {
            if (interval < 0.5)
            {
                vis = false;
                
            }
            else
            {
                interval -= Time.deltaTime;

            }
                
        }
        else
        {
            if (interval > 1)
            {
                vis = true;
                
            }
            else
            {
                interval += Time.deltaTime;
            }
        }
    }


}



