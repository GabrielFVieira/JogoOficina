using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth;
    public float curHealth;
    public GameObject knifePrefab;
    public GameObject medKitPrefab;
	public GameObject littleWaterBottlePrefab;
    public GameObject healthBar;
    public GameObject healthBarContainer;
    public PlayerHealth playerHealth;
    public bool encostando;
    Animator animo;

    public float random;

    public float timer = 0.0f;
    public bool start = false;

    public float delta;
    // Use this for initialization
    void Start()
    {
        delta = 1;


        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        MaxHealth = 100f;
        curHealth = MaxHealth;
        encostando = false;

        animo = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, 5);


        if (start == true)
            timer += Time.deltaTime;

        if (curHealth <= 0)
        {
            animo.SetInteger("Condição", 2);
            start = true;
            healthBarContainer.SetActive(false);

            if (timer >= 1.0f)
            {
                Destroy(gameObject);
                //Drop a Knife
                if (random == 0)
                {
                    GameObject knife = Instantiate(knifePrefab) as GameObject;
                    knife.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
                }
                //Drop a MedKit
                if (random == 1)
                {
                    GameObject medkit = Instantiate(medKitPrefab) as GameObject;
                    medkit.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
                }

				if (random == 2)
				{
					GameObject litteWaterBottle = Instantiate(littleWaterBottlePrefab) as GameObject;
					litteWaterBottle.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
				}
            }
        }

        if (delta <= 0.01f)
        {
            playerHealth.curHealth -= 5;
        }


        if (encostando == true && curHealth > 0)
        {
            delta -= Time.deltaTime;
            //InvokeRepeating("Dano", 0.5f, 2f);
            //animo.SetInteger("Condição", 1); attack number
        }

        if (delta <= 0 || encostando == false)
            delta = 1;
        /*
		else if (encostando == false || curHealth <=0)
        {
            CancelInvoke();
        }*/

    }
    void FixedUpdate()
    {
        float calc_Health = curHealth / MaxHealth;
        SetHealthBar(calc_Health);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            encostando = true;
        }

        if (collision.gameObject.tag == "Weapon")
        {
            curHealth -= 20;
			Destroy(collision.gameObject);
        }

		if (collision.gameObject.tag == "WaterBall")
		{
            Debug.Log("aasdafas");
			curHealth -= 40;
			Destroy(collision.gameObject);
		}
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Body")
        {
            encostando = false;
        }
    }

    void SetHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void Dano()
    {
        playerHealth.curHealth -= 0.05f;


    }
}