using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] private float destroyDelay;
    protected playerController Player;
    // Start is called before the first frame update
    virtual public void Start()
    {
        
    }

    // Update is called once per frame
    virtual public void Update()
    {
        
    }
    protected void Damage() //플레이어에게 데미지
    {
        Player.TakeDamage(damage);

    }
    virtual public void Effect()
    {
        
    }
    protected IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
    virtual public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if(collision.gameObject.CompareTag("Player"))
        {
            Player = collision.GetComponent<playerController>();
            Effect();
            if (damage != 0)
            { Damage(); }
            
            
        }
    }
    virtual public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Player = collision.gameObject.GetComponent<playerController>();
            Effect();
            if (damage != 0)
            { Damage(); }
            

        }
    }
    
}
