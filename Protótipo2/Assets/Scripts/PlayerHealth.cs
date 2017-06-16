using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public PickUpWeapon pick;
    public float MaxHealth;
    public float curHealth;
    public GameObject healthBar;
    public GameObject deathMenu;
    public GameObject hud;
    public GameObject player;

    public GameObject enemies;

    public EnemyHealth enemyHealth;

    public EnemyHealth enemyHealth2;

    public EnemyHealth enemyHealth3;

    //public EnemyHealth enemyHealth4;

    public PickUpWeapon weapon;
    public bool ataque;
    public bool chute;
    public bool encostando;
    public bool encostando2;
    public bool encostando3;
    //public bool encostando4;
    public float dano;
    Animator animo;

    public Camera cam;

	public int golpe;

    public int i;

    public float timer = 0.0f;
    public bool start = false;

    public float delayAttack = 0.0f;
    public bool attackClicked;
    public Collider2D[] colliders;

    public float delay = 1;

    // Use this for initialization
    void Start()
    {
		pick = player.GetComponent<PickUpWeapon> ();

        colliders[0].enabled = false;

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        enemies = GameObject.Find("Enemies" + cam.i);

        hud = GameObject.Find("HUD");
        deathMenu = GameObject.Find("DeathMenu");

        player = GameObject.Find("Player");
        healthBar = GameObject.Find("PlayerHealthBar");
        weapon = player.GetComponent<PickUpWeapon>();

        enemyHealth = GameObject.Find("Enemy").GetComponent<EnemyHealth>();

        enemyHealth2 = GameObject.Find("Enemy2").GetComponent<EnemyHealth>();

        enemyHealth3 = GameObject.Find("Enemy3").GetComponent<EnemyHealth>();

        //enemyHealth4 = GameObject.Find("Enemy4").GetComponent<EnemyHealth>();

        MaxHealth = 100f;
        curHealth = MaxHealth;
        deathMenu.SetActive(false);
        ataque = false;
        chute = false;
        encostando = false;
        encostando2 = false;
        encostando3 = false;
        //encostando4 = false;

        animo = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
		golpe = Random.Range (3, 5);

        //SET PLAYER HEALTH
        if (curHealth > 100)
            curHealth = 100;


        //PLAYER's DEATH
        if (curHealth <= 0)
        {
            animo.SetInteger("Condição", 1);
            start = true;

            hud.SetActive(false);

            if (timer >= 1.0f)
            {
                deathMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }


        //WEAPON IN HUD
        if (weapon.activeWeapon == "none")
            dano = 30f;

        if (weapon.activeWeapon == "Knife")
            dano = 45f;


        //ENEMIES ALIVE
        i = enemies.transform.childCount;


        //ENEMY's IS DEAD
        if (enemyHealth.curHealth <= 0)
            encostando = false;

        if (enemyHealth2.curHealth <= 0)
            encostando2 = false;

        if (enemyHealth3.curHealth <= 0)
            encostando3 = false;
        /*
        if (enemyHealth4.curHealth <= 0)
            encostando4 = false;
            */

        //DESACTIVE ATTACK 
        if (ataque == false && animo.GetCurrentAnimatorStateInfo(0).IsName("soco"))
        {
            animo.SetInteger("Condição", 0);
            colliders[0].offset = new Vector2(0.18f, -0.12f);
            colliders[0].enabled = false;
        }

        if (chute == false && animo.GetCurrentAnimatorStateInfo(0).IsName("chute"))
        {
            animo.SetInteger("Condição", 0);
            colliders[0].offset = new Vector2(0.18f, -0.12f);
            colliders[0].enabled = false;
        }


        //DELAY FOR DEATH ANIMATION
        if (start == true)
            timer += Time.deltaTime;


        //ACTIVE THE ATTACK COLLIDER
        if (ataque == true && animo.GetCurrentAnimatorStateInfo(0).IsName("soco"))
        {
            colliders[0].enabled = true;
            ataque = false;
        }


        //DETECT THE COLLIDING ENEMY AND ATTACK HIM
        if (encostando == true && ataque == true || encostando == true && chute == true)
        {
            enemyHealth.curHealth -= dano;
            ataque = false;
        }

        if (encostando2 == true && ataque == true || encostando2 == true && chute == true)
        {
            enemyHealth2.curHealth -= dano;
            ataque = false;
        }

        {
            if (encostando3 == true && ataque == true || encostando3 == true && chute == true)
                enemyHealth3.curHealth -= dano;
            ataque = false;
        }

        /*
        if (encostando4 == true && ataque == true || encostando4 == true && chute == true)
        {
            enemyHealth4.curHealth -= dano;
            ataque = false;
        }
        */



        /*
        if (ataque == true)
        {
            colliders[0].enabled = true;
            enemyHealth.curHealth -= dano;
            //ataque = false;
            delay -= Time.deltaTime;
        }

        if (chute == true && delay <= 0)
        {
            colliders[1].enabled = true;
            delay -= Time.deltaTime;
        }

		if (enemyHealth.curHealth <= 0)
			encostando = false;

		if (enemyHealth2.curHealth <= 0)
			encostando2 = false;

        if (enemyHealth3.curHealth <= 0)
            encostando3 = false;

        if (enemyHealth4.curHealth <= 0)
            encostando4 = false;
*/
    }

    void FixedUpdate()
    {
        if (curHealth >= 0)
        {
            float calc_Health = curHealth / MaxHealth;
            SetHealthBar(calc_Health);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Body1")
        {
            encostando = true;
        }

        if (collision.gameObject.name == "Body2")
        {
            encostando2 = true;

        }

        if (collision.gameObject.name == "Body3")
        {
            encostando3 = true;

        }
        /*
        if (collision.gameObject.name == "Body4")
        {
            encostando4 = true;

        }*/
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Body1")
		{
            encostando = false;
        }

        if (collision.gameObject.name == "Body2")
        {
            encostando2 = false;

        }

        if (collision.gameObject.name == "Body3")
        {
            encostando3 = false;

        }
        /*
        if (collision.gameObject.name == "Body4")
        {
            encostando4 = false;

        }*/
    }

    void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public void Attack(bool attack)
    {
		if (pick.crounch == false) {
			ataque = attack;
			colliders [0].offset = new Vector2 (0.45f, -0.12f);
			animo.SetInteger ("Condição", golpe);

		}
    }
}