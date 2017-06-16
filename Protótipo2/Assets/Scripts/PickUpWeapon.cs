using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpWeapon : MonoBehaviour {
	public GameObject knife;
    public GameObject medkit;
	public GameObject waterBottleLittle;
    public bool crounch;
	public bool colliding;
    public bool collidingMK;
	public bool collidingWBL;
    public string activeWeapon;
    public PlayerHealth playerHealth;
	public PlayerWater playerWater;
	public bool CanPickUp;
	public Animator animo;
	// Use this for initialization
	public void Start () {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
		playerWater = GameObject.Find("Player").GetComponent<PlayerWater>();
		animo = GetComponent<Animator> ();
		activeWeapon = "none";
		crounch = false;
		colliding = false;
	}
	
	// Update is called once per frame
	public void Update () {
		GameObject knife = GameObject.Find ("KnifePrefab(Clone)");
        GameObject medkit = GameObject.Find("MedKitPrefab(Clone)");
		GameObject waterBottleLittle = GameObject.Find("WaterBottleLittlePrefab(Clone)");


			animo.SetBool("Crouch", crounch);


        if (colliding == true && crounch == true && activeWeapon != "Knife")  
		{
			//Destroy (knife.gameObject);
			activeWeapon = "Knife";
			colliding = false;
			animo.SetBool("Crouch", crounch);
			//crounch = false;
			CanPickUp = false;
		}

        if (collidingMK == true && crounch == true)
        {
            //Destroy(medkit.gameObject);
            collidingMK = false;
            playerHealth.curHealth += 50;
			animo.SetBool("Crouch", crounch);
			//crounch = false;
			CanPickUp = false;
        }

		if (collidingWBL == true && crounch == true)
		{
			//Destroy(waterBottleLittle.gameObject);
			collidingWBL = false;
			playerWater.curWater += 20;
			animo.SetBool("Crouch", crounch);
			//crounch = false;
			CanPickUp = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Item") {
			CanPickUp = true;		
		}

		if (col.gameObject.name == "KnifePrefab(Clone)") {
			colliding = true;
		}

        if (col.gameObject.name == "MedKitPrefab(Clone)")
        {
            collidingMK = true;
        }

		if (col.gameObject.name == "WaterBottleLittlePrefab(Clone)") {
			collidingWBL = true;
		}
    }

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Item") {
			CanPickUp = false;		
		}

		if (col.gameObject.name == "KnifePrefab(Clone)") {
			colliding = false;
		}
        if (col.gameObject.name == "MedKitPrefab(Clone)")
        {
            collidingMK = false;
        }
		if (col.gameObject.name == "WaterBottleLittlePrefab(Clone)") {
			collidingWBL = false;
		}
    }

	public void Agaichar(bool agaichar)
	{
		if(CanPickUp == true)
		crounch = agaichar;
	}
}
