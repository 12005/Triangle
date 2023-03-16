using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject BulletPrefab;
    public ParticleSystem ShootEffect;
    public float Firerate = 1;
    public int Damage = 1;

    public void SpawnBullet()
    {
        Instantiate(ShootEffect, GameObject.Find("firePoint").transform.position , GameObject.Find("Player").transform.rotation * Quaternion.Euler(-90,0,0) );
        Instantiate(BulletPrefab, GameObject.Find("firePoint").transform.position, Quaternion.identity);
    }
}
