using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Drops : MonoBehaviour
{
    public void Drop(GameObject[] drop, Transform objectTransform)
    {
        if(Random.Range(0, 1) <= Stats.dropChance)
        {
            Instantiate(drop[Random.Range(0, drop.Length)], objectTransform.position, Quaternion.identity);
        }
    } 
}
