using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolEffect : MonoBehaviour
{
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public GameObject echo;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if(player.movement != Vector2.zero)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject effect = (GameObject)Instantiate(echo, transform.position, player.transform.rotation);
                Destroy(effect, 1f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }

}