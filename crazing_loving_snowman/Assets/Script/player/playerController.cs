using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public Rigidbody2D PlayerRigidbody { get => playerRigidbody; }
    private Transform playerTrans;
    public SpriteRenderer playerRender;
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
    
    public float tmpTime;
    private float scale;
    private float plusHp;
    private float zInput;



    [SerializeField] private FaceUI faceUI;
    public FaceUI FaceUI { get => faceUI; }
    [SerializeField] private List<FaceData> nullData = new List<FaceData>();
    private int startIndex;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerTrans = GetComponent<Transform>();
        playerRender = GetComponent<SpriteRenderer>();
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1; //Å¬¸®¾î ½Ã ÇØ±ÝµÇ´Â ¾À ¹øÈ£
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

        
        startIndex = (SceneManager.GetActiveScene().buildIndex - 3) * 3;
        
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
        if (collision.gameObject.tag == "Ground") //´«µ¢ÀÌ Å°¿ì±â
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

        if (collision.gameObject.tag == "Scoop")
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "dmgTrap")
    //    {
    //        onDamage();
    //        Invoke("unDamage", 3);
    //    }


    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //´«ÄÚÀÔ È¹µæ
        if (collision.gameObject.tag == "Face")
        {

            Face face = collision.GetComponent<Face>();
            faceUI.FaceScoreData.Add(face.FaceData);
            faceUI.AcquireItem(face, 1);
            faceUI.ScoreChange(face);
            Destroy(collision.gameObject);

        }
        // ´«µ¢ÀÌ¿¡ µµÂø
        if (collision.gameObject.tag == "Finish")
        {
            UIPanel.SetActive(false);
            ClearPanel.SetActive(true);


            if (faceUI.FaceScoreData.Faces.Count < startIndex + 3)
            {
                while (faceUI.FaceScoreData.Faces.Count < startIndex + 3)
                {
                    faceUI.FaceScoreData.Add(nullData[startIndex]); //È¹µæ ¸øÇÑ °÷¿¡ nullµ¥ÀÌÅÍ
                }

            }

            if (faceUI.FaceScoreData.Faces.Find(face => face.FaceType == 5) == null) // µ¥ÀÌÅÍÁß¿¡ nullÀÌ ¾øÀ¸¸é Å¬¸®¾î
            {
                NextStage.color = new Color(1, 1, 1, 1);
                NextStageBtn.SetActive(true);

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad); //Å¬¸®¾î ½Ã ÇØ±ÝµÇ´Â ¾À ¹øÈ£ ÀúÀåÇØ¼­ ³Ñ±â±â
                }

                Debug.Log("²Ü¸®¾î");
            }
        }

        //if (collision.gameObject.tag == "dmgTrap")
        //{
        //    onDamage();
        //    Invoke("unDamage", 3);

        //    if (collision.gameObject.name == "wRabbit")
        //    {
        //        bounce(collision.transform.position);
        //    }
        //}

        //if (collision.gameObject.tag == "snowduck")
        //{
        //    hp = hp - 15;
        //}

        if (collision.gameObject.tag == "eRabbit")
        {
            int randomFace = Random.Range(1, 3);
            loseFace(randomFace);
        }

        
        
        if (collision.gameObject.tag == "Mushroom")
        {
            movement = false;
            Invoke("playerMove", 5f);
        }


    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "snowduck")
    //    {
    //        tmpTime += Time.deltaTime;

          
    //        if (tmpTime >= 1.5f)
    //        {
    //            movement = true;
    //            playerRender.color = new Color(1, 1, 1, 1);
    //        }
    //        else
    //        {
    //            movement = false;
    //            playerRigidbody.velocity = new Vector2(0, 0);
    //            playerRender.color = new Color(1, 1, 1, 0);
    //            transform.position = collision.transform.position;
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "snowduck")
    //    {
    //        tmpTime = 0;
    //    }
    //}




    public void playerMove(bool move)
    {
        movement = move;
    }

    private void playerScale() // ´«µ¢ÀÌ ±¼¸®¸é Å©±â Ä¿Áü
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


    public void bounce(Vector2 enemyPos)
    {
        int dirc = enemyPos.x - transform.position.x < 0 ? 1 : -1;
        playerRigidbody.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

    }
    //µ¥¹ÌÁö ÀÔÀ»¶§ ±ôºý°Å¸®±â
    //private void onDamage()
    //{
    //    gameObject.layer = 7;
    //    Dmg = true;
    //    StartCoroutine(unDamage());
    //}
    private IEnumerator unDamage()
    {
        yield return new WaitForSeconds(3.0f);

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
   

    public void TakeDamage(int damage)
    {
        hp -= damage;
        gameObject.layer = 7;
        Dmg = true;
        StartCoroutine(unDamage());
    }
}



