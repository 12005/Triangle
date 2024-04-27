using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Assertions.Must;

public class Player : MonoBehaviour
{
    public float moveSpeed = Stats.maxPlayerSpeed; 
    public Vector2 movement;
    private Animator animator;

    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;

    //public Weapon[] Weapons;
    public Weapon CurrentWeapon;
    public float firerate;
    public float timeBtwShoot = 0f;

    [SerializeField]
    private float health = Stats.maxPlayerHealth;
    public HealthManage healthManage;
    public static bool isHit = false;

    public LevelUpMenu levelUpMenu;
    public XpManage xpManage;
    public int level = 1;
    public int xp = 0;
    public int xpMax = 30;

    public Joystick moveJoystick;
    public Joystick shootJoystick;
    [HideInInspector]
    public bool canShoot = true;

    public int HighScore;

    public AudioClip[] audioClips;
    public GameObject DeathScreen;

    private void Awake()
    {
        healthManage.setMaxHealth(Stats.maxPlayerHealth);
        isHit = false;
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        PlayerPrefs.GetInt("HighScore", 0);
        /*if (PlayerPrefs.GetString("WeaponName") == "p")
        {
            CurrentWeapon = Weapons[0];
        }
        else if (PlayerPrefs.GetString("WeaponName") == "fp")
        {
            CurrentWeapon = Weapons[1];
        }
        else if (PlayerPrefs.GetString("WeaponName") == "gs")
        {
            CurrentWeapon = Weapons[2];
        }*/
        firerate = CurrentWeapon.Firerate;
    }
    
    void Update()
    {
        Rotation();
        if (shootJoystick.Horizontal >= 0.6 || shootJoystick.Vertical >= 0.6)
            shoot();
        if (shootJoystick.Horizontal <= -0.6 || shootJoystick.Vertical <= -0.6)
            shoot();

        if (xp >= xpMax) {
            level += 1;
            xp -= xpMax; 
            xpMax = 30 + (int)(30 * math.log(level));
            levelUpMenu.pickAbility();
            xpManage.levelup();
        }
        firerate = CurrentWeapon.Firerate;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (((collision.gameObject.tag == "enemyTri") && isHit == false))
        {
            takeDamage(Stats.enemyTriHit);
        }
        if (((collision.gameObject.tag == "enemyHex") && isHit == false))
        {
            takeDamage(Stats.enemyHexHit);
        }
        if (((collision.gameObject.tag == "enemyBullet") && isHit == false))
        {
            takeDamage(Stats.enemyBulletHit);
        }
        if (((collision.gameObject.tag == "basicHeal")))
        {
            heal(Stats.basicHeal);
            Destroy(collision.gameObject);
        }
        if ((collision.gameObject.tag == "basicInvulnerable"))
        {
            isHit = true;
            StartCoroutine(onHit(Stats.basicInvulnerable));
            Destroy(collision.gameObject);
        }
        if (((collision.gameObject.tag == "basicXp")))
        {
            xp += Stats.basicXp;
            Destroy(collision.gameObject);
        }
    }

    void Movement()
    {
        movement.x = moveJoystick.Horizontal;
        movement.y = moveJoystick.Vertical;

        rb.velocity = movement.normalized * moveSpeed;



    }

    void Rotation()
    {
        float angle = Mathf.Atan2(shootJoystick.Horizontal, shootJoystick.Vertical) * Mathf.Rad2Deg;

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
                CurrentWeapon.SpawnBullet(transform);
                timeBtwShoot = Time.time + 1 / CurrentWeapon.Firerate;
            }
    }

    IEnumerator onHit(float time)
    {
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(time);
        isHit = false;
        animator.ResetTrigger("Hit");
    }

    public void heal(float amount)
    {
        if((health+amount) <= Stats.maxPlayerHealth)
        {
            health += amount;
            healthManage.setHealth(health);
        }
    }

    public void takeDamage(float damage)
    {
        if (isHit == false)
        {
            isHit = true;
            health = health - damage;
            healthManage.setHealth(health);
            if (health <= 0)                                                                                                //check if health is zero before blink
            {
                if (Score_Manager.ScoreValue > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", Score_Manager.ScoreValue);
                    HighScore = PlayerPrefs.GetInt("HighScore", 0);
                }
                StartCoroutine(death());    
            }

            StartCoroutine(onHit(Stats.invulnerableTime));
        }
    }

    IEnumerator death()
    {
        rb.simulated = false;
        playerSprite.color = new Color(0, 0, 0, 0);
        moveJoystick.gameObject.SetActive(false);
        shootJoystick.gameObject.SetActive(false);
        DeathScreen.SetActive(true);
        soundManager.instance.playSoundFX(audioClips[0]);
        
        yield return new WaitForSeconds(6);
        
        Destroy(this.gameObject);
        SceneManager.LoadScene(2);
        
    }
 
}
