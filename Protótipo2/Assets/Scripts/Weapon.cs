using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject player;
    public float maxDistance = 30.0f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x + maxDistance < transform.position.x)
        {
            Destroy(gameObject);
        }

        if (player.transform.position.x > transform.position.x + maxDistance)
        {
            Destroy(gameObject);
        }
    }
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			Destroy(gameObject);
		}

		if (collision.gameObject.tag == "WorldProps") {
			Destroy(gameObject);
		}
	}
}
