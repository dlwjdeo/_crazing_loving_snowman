using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveRabbit : Trap
{
    Rigidbody2D rigid;
    Animator rani;
    SpriteRenderer render;
    public int nextMove;
    public int h;
    public float rabbitSpeed;
    public float speed;
    public int rabbitJumpCount;
    private int jumpCount = 0;
    private int turn = 1;

    override public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rani = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
    override public void Update()
    {

        if (rigid.velocity.y > 0)
        {

            rani.SetBool("Jump", true);
        }
        else
        {
            rani.SetBool("Jump", false);
        }

        if (rigid.velocity.x > 0)
        {
            render.flipX = true;
        }
        else
        {
            render.flipX = false;
        }

    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(rabbitSpeed, rigid.velocity.y);
    }

    override public void OnCollisionEnter2D(Collision2D collision)
    {
        rabbitSpeed = 0;
        StartCoroutine("jumpRabbit");
        turnDirection();
        if (collision.gameObject.CompareTag("Player"))
        {    
            if (gameObject.CompareTag("wRabbit"))
            {
                Damage();
                Player.bounce(gameObject.transform.position);
            }
            else
            {
                Steal();
            }
        }

        //rabbitSpeed = 0;
        //Invoke("jumpRabbit", 2f);
        //turnDirection();
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        rabbitSpeed = -speed * turn;
        jumpCount++;
    }
    IEnumerator jumpRabbit()
    {
        yield return new WaitForSeconds(2.0f);
        rigid.AddForce(Vector2.up * h, ForceMode2D.Impulse);
    }
    void turnDirection()
    {
        if (jumpCount >= rabbitJumpCount)
        {
            turn = turn * (-1);
            jumpCount = 0;
        }
    }
   
    private void Steal()
    {
        if (Player.FaceUI.FaceScoreData.Faces != null)
        {
            int random = Random.Range(0, 2);
            int index = Player.FaceUI.FaceScoreData.Faces.FindIndex(face => face.FaceType == random && face.StageNum == SceneManager.GetActiveScene().buildIndex - 2);

            Player.FaceUI.FaceScoreData.Faces.Remove(Player.FaceUI.FaceScoreData.Faces[index]);
        }
    }

}
