using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject BulletPrefab;
    public ParticleSystem ShootEffect;
    public bool IsMelee = false;
    public float Firerate = 1;
    public int Damage = 1;

    public void SpawnBullet(Transform player_pos)
    {
        Instantiate(ShootEffect, GameObject.Find("firePoint").transform.position , GameObject.Find("Player").transform.rotation * Quaternion.Euler(-90,0,0) );
        if(IsMelee)
            Instantiate(BulletPrefab, GameObject.Find("firePoint").transform.position, Quaternion.identity,player_pos);
        else
            Instantiate(BulletPrefab, GameObject.Find("firePoint").transform.position, Quaternion.identity);
    }
}
