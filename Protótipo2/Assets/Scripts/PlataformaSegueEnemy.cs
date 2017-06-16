using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSegueEnemy : MonoBehaviour {
	public GameObject enemy;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(enemy.transform.position.x, transform.position.y, transform.position.z);
	}
}
