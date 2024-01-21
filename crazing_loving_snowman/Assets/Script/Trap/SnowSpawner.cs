using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject snowPrefab;

    public bool falling = true;
    public bool startFalling = true;
    public Transform spawnerPosition;

    void Update()
    {
        if (falling)
        {
            falling = false;
            StartCoroutine(fallingDelay());
        }
    }

    IEnumerator fallingDelay()
    {
        while (startFalling)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(snowPrefab, spawnerPosition.position,spawnerPosition.rotation);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "startfalling")
        {
            startFalling = true;
            falling = true;
        }

        if (collision.gameObject.name == "endfalling")
        {
            startFalling = false;
        }
    }
}
