using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class icicle : MonoBehaviour
{

    private SpriteRenderer icRen;
    public GameObject ic;
    private float ictime;
    private BoxCollider2D icollider;

    // Start is called before the first frame update
    void Start()
    {
        icRen = GetComponent<SpriteRenderer>();
        icollider = GetComponent<BoxCollider2D>();
        ictime = 7;
    }

    // Update is called once per frame
    void Update()
    {
        ictime += Time.deltaTime;
        if (ictime > 7)
        {
            icollider.enabled = true;
            icRen.color = new Color(1, 1, 1, 1);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ictime = 0;
            icRen.color = new Color(1, 1, 1, 0);
            GameObject icicle = Instantiate(ic, transform.position, Quaternion.Euler(0, 0, 180));
            icollider.enabled = false;
        }
    }
}
