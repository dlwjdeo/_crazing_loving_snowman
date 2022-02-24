using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Transform playerTrans;
    private SpriteRenderer playerRender;
    public GameObject ClearPanel;
    public GameObject UIPanel;
    public GameObject gameover;
    public GameObject NextStageBtn;
    public Image FacePanelEye;
    public Image FacePanelNose;
    public Image FacePanelMouse;
    public Image ClearPanelEyeL;
    public Image ClearPanelEyeR;
    public Image ClearPanelNose;
    public Image ClearPanelMouse;
    public Image NextStage;
    public int nextSceneLoad;
    public bool gameOver;
    public float hp;
    private float pos;
    private bool Dmg;
    private float interval;
    private bool vis;
    private int Lvalue;
    private int Rvalue;
    private float maxSpeed;
    private bool eye;
    private bool nose;
    private bool mouse;
    public bool Lscoop;
    public bool Rscoop;
    public bool movement;
    private float tmpTime;
    private float scale;
    private float plusHp;
    private float zInput;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();
        playerRender = GetComponent<SpriteRenderer>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
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
        Lscoop = false;
        Rscoop = false;
        scale = 0.5f;
        plusHp = 1;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            if (playerRigidbody.velocity.x <= maxSpeed)
            {
                zInput = Input.GetAxisRaw("Horizontal") + Lvalue + Rvalue;
                playerRigidbody.AddForce(new Vector2(zInput, 0));
            }

        }

        

        if (Dmg == true)
        {
            invisible();
        }
        playerScale();

        if (hp <= 0)
        {
            GameOver();
        }

        if (hp > 100)
        {
            hp = 100;
        }

        if (Lscoop == true)
        {
            playerRigidbody.AddForce(Vector2.left * 5, ForceMode2D.Impulse);
            Lscoop = false;
        }

        if (Rscoop == true)
        {
            playerRigidbody.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
            Rscoop = false;
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
                    hp = hp + plusHp;
                    pos = playerTrans.position.x;
                }
                else if (playerTrans.position.x - pos < -1)
                {
                    hp = hp + plusHp;
                    pos = playerTrans.position.x;
                }

            }

        }

        if (collision.gameObject.name == "Scoop")
        {
            
            
            movement = false;
        }
    }

    private void GameOver()
    {
        gameObject.SetActive(false);
        UIPanel.SetActive(false);
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
            ClearPanel.SetActive(true);

            if (eye == true && nose == true && mouse == true)
            {
                NextStage.color = new Color(1, 1, 1, 1);
                NextStageBtn.SetActive(true);
            
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                 }
            }

            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                if (eye == true)
                {
                    PlayerPrefs.SetInt("eye1", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("eye1", System.Convert.ToInt16(false));
                }

                if (nose == true)
                {
                    PlayerPrefs.SetInt("nose1", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("nose1", System.Convert.ToInt16(false));
                }

                if (mouse == true)
                {
                    PlayerPrefs.SetInt("mouse1", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("mouse1", System.Convert.ToInt16(false));
                }
            }

            else if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                if (eye == true)
                {
                    PlayerPrefs.SetInt("eye2", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("eye2", System.Convert.ToInt16(false));
                }

                if (nose == true)
                {
                    PlayerPrefs.SetInt("nose2", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("nose2", System.Convert.ToInt16(false));
                }

                if (mouse == true)
                {
                    PlayerPrefs.SetInt("mouse2", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("mouse2", System.Convert.ToInt16(false));
                }
            }

            else if (SceneManager.GetActiveScene().buildIndex == 5)
            {
                if (eye == true)
                {
                    PlayerPrefs.SetInt("eye3", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("eye3", System.Convert.ToInt16(false));
                }

                if (nose == true)
                {
                    PlayerPrefs.SetInt("nose3", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("nose3", System.Convert.ToInt16(false));
                }

                if (mouse == true)
                {
                    PlayerPrefs.SetInt("mouse3", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("mouse3", System.Convert.ToInt16(false));
                }
            }

            else if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                if (eye == true)
                {
                    PlayerPrefs.SetInt("eye4", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("eye4", System.Convert.ToInt16(false));
                }

                if (nose == true)
                {
                    PlayerPrefs.SetInt("nose4", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("nose4", System.Convert.ToInt16(false));
                }

                if (mouse == true)
                {
                    PlayerPrefs.SetInt("mouse4", System.Convert.ToInt16(true));
                }
                else
                {
                    PlayerPrefs.SetInt("mouse4", System.Convert.ToInt16(false));
                }
            }




        }


        if (collision.gameObject.tag == "snowduck")
        {
            hp = hp - 15;
        }

        if (collision.gameObject.name == "eRabbit")
        {
            int randomFace = Random.Range(1, 3);
            loseFace(randomFace);
        }

        if (collision.gameObject.tag == "Eye")
        {
            FacePanelEye.color = new Color(1, 1, 1, 1);
            ClearPanelEyeL.color = new Color(1, 1, 1, 1);
            ClearPanelEyeR.color = new Color(1, 1, 1, 1);
            eye = true;

        }

        if (collision.gameObject.tag == "Nose")
        {
            FacePanelNose.color = new Color(1, 1, 1, 1);
            ClearPanelNose.color = new Color(1, 1, 1, 1);
            nose = true;
        }

        if (collision.gameObject.tag == "Mouse")
        {
            FacePanelMouse.color = new Color(1, 1, 1, 1);
            ClearPanelMouse.color = new Color(1, 1, 1, 1);
            mouse = true;
        }

        if (collision.gameObject.tag == "Mushroom")
        {
            movement = false;
            Invoke("playerMove", 5f);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "snowduck")
        {
            tmpTime += Time.deltaTime;

            if (tmpTime >= 1.5f)
            {
                movement = true;
                playerRender.color = new Color(1, 1, 1, 1);
            }
            else
            {
                movement = false;
                playerRigidbody.velocity = new Vector2(0, 0);
                playerRender.color = new Color(1, 1, 1, 0);
                transform.position = collision.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "snowduck")
        {
            tmpTime = 0;
        }
    }




    private void playerMove()
    {
        movement = true;
    }

    private void playerScale()
    {
        if (hp < 24)
        {
            playerTrans.localScale = new Vector2(1 * scale, 1 * scale);
            playerRigidbody.mass = 1 * scale;
        }
        else if (hp < 49)
        {
            playerTrans.localScale = new Vector2(1.2f * scale, 1.2f * scale);
            playerRigidbody.mass = 1.2f * scale;
        }
        else if (hp < 74)
        {
            playerTrans.localScale = new Vector2(1.5f * scale, 1.5f * scale);
            playerRigidbody.mass = 1.5f * scale;
        }
        else if (hp < 99)
        {
            playerTrans.localScale = new Vector2(1.8f * scale, 1.8f * scale);
            playerRigidbody.mass = 1.8f * scale;
        }
        else if (hp >= 100)
        {
            playerTrans.localScale = new Vector2(2 * scale, 2 * scale);
            playerRigidbody.mass = 2 * scale;
        }
    }

    private void loseFace(int face)
    {
        if (face == 1)
        {
            if (eye)
            {
                FacePanelEye.color = new Color(1, 1, 1, 0.4f);
                ClearPanelEyeL.color = new Color(1, 1, 1, 0);
                ClearPanelEyeR.color = new Color(1, 1, 1, 0);
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
                ClearPanelNose.color = new Color(1, 1, 1, 0);
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
                ClearPanelMouse.color = new Color(1, 1, 1, 0);
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

        if (vis)
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



