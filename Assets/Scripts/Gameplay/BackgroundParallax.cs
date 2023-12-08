using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class BackgroundParallax : MonoBehaviour
{

    public Vector2 startpos;
    public Vector2 lenght;
    public GameObject cam;
    public float parallaxEffect;
  
    void Start()
    {
        startpos = transform.position;
        lenght = GetComponent<SpriteRenderer>().bounds.size;
        Debug.Log(lenght+" \n"+parallaxEffect);
    }

    void Update()
    {
        Vector2 dist, temp;
        temp.x = cam.transform.position.x *(1 - parallaxEffect);
        temp.y = cam.transform.position.y * (1 - parallaxEffect);

        dist.x = cam.transform.position.x * parallaxEffect;
        dist.y = cam.transform.position.y * parallaxEffect;

        transform.position = new Vector3(startpos.x + dist.x, startpos.y + dist.y, transform.position.z);

        if (temp.x > startpos.x + lenght.x) { startpos.x += lenght.x; Debug.Log("X+"); }
        else if (temp.x < startpos.x - lenght.x) { startpos.x -= lenght.x; Debug.Log("X-"); }
        if (temp.y > startpos.y + lenght.y) { startpos.y += lenght.y; Debug.Log("Y+"); }
        else if (temp.y < startpos.y - lenght.y) { startpos.y -= lenght.y; Debug.Log("Y-"); }
    }
}
