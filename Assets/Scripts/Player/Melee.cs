using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float swing_speed = 1000f;

    public float rotateSpeed = 70f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(swing());   
    }

    void Update()
    {
        float angle = rotateSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    IEnumerator swing()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
