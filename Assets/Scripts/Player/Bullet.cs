using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;

    private Vector2 fireDirection;

    void Start()
    {
        fireDirection = GameObject.Find("direction").transform.position;
        transform.position = GameObject.Find("firePoint").transform.position;

    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, fireDirection, bulletSpeed * Time.deltaTime);
        Destroy(this.gameObject, 4f);
    }

}
