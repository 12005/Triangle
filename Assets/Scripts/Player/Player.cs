using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movement;
    private Animator animator;

    public Rigidbody2D rb;

    public Weapon CurrentWeapon; 
    public float timeBtwShoot = 0f;

    [SerializeField]
    private int health;
    private bool isHit = false;

    public Joystick moveJoystick;
    public Joystick shootJoystick;
    [HideInInspector]
    public bool canShoot = true;

    public int HighScore;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        Rotation();
        if (shootJoystick.Horizontal >= 0.6 || shootJoystick.Vertical >= 0.6)
            shoot();
        if (shootJoystick.Horizontal <= -0.6 || shootJoystick.Vertical <= -0.6)
            shoot();
    }

    private void FixedUpdate()
    {
        Movement();    
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (((collision.gameObject.tag == "Enemy") && isHit == false))
        {
            takeDamage(1);
        }
    }

    void Movement()
    {
        movement.x = moveJoystick.Horizontal;
        movement.y = moveJoystick.Vertical;

        rb.MovePosition(rb.position + movement.normalized * Time.fixedDeltaTime * moveSpeed);

    }

    void Rotation()
    {
        float angle = Mathf.Atan2(shootJoystick.Horizontal, shootJoystick.Vertical) * Mathf.Rad2Deg ;

        if (angle != 0)
        {
            Quaternion rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
        }
    }

    private void shoot()
    {
        if (Input.GetMouseButton(0))
            if (Time.time >= timeBtwShoot)
            {
                CurrentWeapon.SpawnBullet();
                timeBtwShoot = Time.time + 1 / CurrentWeapon.Firerate;
            }
    }

    IEnumerator onHit()
    {
     animator.SetTrigger("Hit");
     yield return new WaitForSeconds(1f);
     isHit = false;
     animator.ResetTrigger("Hit");
    }

    public void takeDamage(int damage)
    {
        if(isHit == false)
        {
            isHit = true;
            health = health - damage;
            for (int i = 0; i < damage; i++)
            {
                Destroy(GameObject.Find("Health Box").transform.GetChild(i).gameObject);
            }
            if (health <= 0)                                                                                                //check if health is zero before blink
            {
                if(Score_Manager.ScoreValue > PlayerPrefs.GetInt("HighScore" , 0))
                {
                    PlayerPrefs.SetInt("HighScore", Score_Manager.ScoreValue);
                    HighScore = PlayerPrefs.GetInt("HighScore", 0);
                }
                Destroy(this.gameObject);
                SceneManager.LoadScene(2);
            }

            StartCoroutine(onHit());
        }
    }

}
