using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hex : MonoBehaviour
{
    public float speed;
    public float hitPoints;
    private Transform playerPos;
    public float followDistance;
    public float DestoryDistance;

    private Player player;

    SpriteRenderer sr;
    Color defaultColor;
    public ParticleSystem deathEffect;
    public ParticleSystem explode;


    void Awake()
    {
        player = GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        defaultColor = sr.color;
    }

    void Update()
    {
        enemyMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            onHit();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            enemyExplode();
        }
            
            
    }

    void onHit()
    {
        hitPoints -= GameObject.Find("Player").GetComponent<Player>().CurrentWeapon.Damage;
        if (hitPoints <= 0)                                                                                         //check if health is zero before changing color
        {   
            Destroy(this.gameObject);
            Score_Manager.ScoreValue += 50;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        StartCoroutine(changeColor());
    }

    IEnumerator changeColor()
    {
        sr.color = new Color(0.8901961f, 0f, 0.08141669f, 0.6450981f);
        yield return new WaitForSeconds(0.2f);
        sr.color = defaultColor;

    }

    void enemyMovement()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > followDistance)                                                     //movement
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, playerPos.position) > DestoryDistance){
            Destroy(this.gameObject);                                                                                                     //destory if too much distance
        }

        Vector3 direction = playerPos.position - transform.position;                                                            //rotation
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    void enemyExplode()
    {
        StartCoroutine(destory());
        player.takeDamage(1);
    }

    IEnumerator destory()
    {
        yield return new WaitForSeconds(0.05f);
        Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
