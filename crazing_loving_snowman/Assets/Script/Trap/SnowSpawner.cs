using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] snowPrefab;
    [SerializeField]
    private int num;
   public bool falling = true;
    public bool startFalling = true;
    public Transform spawnerPosition;

    //void Update()
    //{
    //    if (falling)
    //    {
    //        falling = false;
    //        StartCoroutine(fallingDelay());
    //    }
    //}


    //IEnumerator fallingDelay()
    //{
    //    while (startFalling)
    //    {
    //        yield return new WaitForSeconds(0.5f);
    //        Instantiate(snowPrefab, spawnerPosition.position,spawnerPosition.rotation);

    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "startfalling")
    //    {
    //        startFalling = true;
    //        falling = true;
    //    }

    //    if (collision.gameObject.name == "endfalling")
    //    {
    //        startFalling = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Spawn();
        }
    }
    Vector2 SpawnPosition()
    {
        
        float x = Random.Range(gameObject.transform.position.x - 4, transform.position.x + 4);
        Vector2 position = new Vector2(x, gameObject.transform.position.y);

        return position;
    }

    void Spawn()
    { 
        for (int i = 0; i < num; i++)
            randomspawn();
    }
    void randomspawn()
    {
        int random = Random.Range(0, 2);
        Instantiate(snowPrefab[random], SpawnPosition(), Quaternion.identity);
    }
}
