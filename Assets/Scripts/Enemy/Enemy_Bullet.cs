using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    private Player player;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    void Start()
    {
        rb.velocity = transform.up * bulletSpeed;
        Destroy(this.gameObject, 2.5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(destroy());
            player.takeDamage(1);
        }
        if(collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.03f);
        Destroy(this.gameObject);
    }
}
